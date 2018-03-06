using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using WaterAMR.DataAccess.Interfaces;
using WaterAMR.DataModels.Payment;
using WaterAMR.DataRepository;
using Microsoft.EntityFrameworkCore;
using WaterAMR.Utility;
using WaterAMR.DataModels;

namespace WaterAMR.DataAccess
{
    public class PaymentRepository : DataStore, IPaymentRepository
    {
        private DbSet<PaymentDetail> PaymentDetail { get; set; }
        private DbSet<DataModels.Billing.Bill> Bill { get; set; }
        private DbSet<DataModels.Billing.BillGroupDetail> BillGroupDetail { get; set; }
        private DbSet<DataModels.User.employeeloginmapping> EmployeeLoginMapping { get; set; }
        private DbSet<DataModels.User.employee> Employee{ get; set; }
        private DbSet<DataModels.UnitSummary.UnitSummary> UnitSummary { get; set; }
        private DbSet<DataModels.Payment.PaymentProcess> PaymentProcess { get; set; }
        private IUserInjection Context; 
        public PaymentRepository(IConfiguration configHelper, IUserInjection context) : base(configHelper)
        {
            Context = context;
        }

        public string AddPayment(PaymentDetail detail)
        {
            var result = "Success";
            detail.AddedAt = DateTime.Now;
            var userid = Context.GetUser();
            var emp = (from empl in EmployeeLoginMapping where empl.employeeid == userid select empl).FirstOrDefault();
            detail.AddedBy =emp==null ?"": emp.loginname;
            var r = PaymentDetail.Add(detail);
            this.SaveChanges();
            return result;
        }

        public PaymentResultVM GetPayments(long BillNo)
        {
            var result = new PaymentResultVM();

            result.Payments = from pd in PaymentDetail
                           where pd.BillNo == BillNo  
                           select pd;
            result.TotalAmount = result.Payments.Where(o => !o.Canceled).Sum(ob => ob.Amount);
            return result;
        }
        public PaymentAuthenticationVM GetAuthenticationData(string date)
        {


            var result = new PaymentAuthenticationVM();
            var qry = from bill in Bill
                                        join pay in PaymentDetail on bill.Id equals pay.BillNo
                                        where pay.AddedAt.Date == Convert.ToDateTime(date).Date && pay.Canceled == false
                                        orderby pay.AddedAt
                                        select new PaymentAuthenticaionResult { Bill = bill, Payment = pay };
            var userid = Context.GetUser();
            var emp = (from empl in Employee where empl.employeeid == userid select empl).FirstOrDefault();
            if (emp.divisionid != null)
            {
                qry = from paydata in qry
                      join us in UnitSummary on paydata.Bill.UnitId equals us.id
                      where us.divisionid == emp.divisionid
                      select paydata;
            }
            result.AuthenticationData = qry;
                result.TotalAmount = result.AuthenticationData.Sum(ob => ob.Payment.Amount);
            result.Authenticated = result.AuthenticationData.Any() ? result.AuthenticationData.FirstOrDefault().Payment.Authenticated : false;
            return result;
        }
        public string Authenticate(string date)
        {
            var result = "Success";
            try
            {
                var userid = Context.GetUser();
                var emp = (from empl in EmployeeLoginMapping where empl.employeeid == userid select empl).FirstOrDefault();
                var empDetail = (from empl in Employee where empl.employeeid == userid select empl).FirstOrDefault();
                var qry = from pd in PaymentDetail
                          where pd.AddedAt.Date == Convert.ToDateTime(date).Date && pd.Canceled == false
                          select pd;

                if (empDetail.divisionid != null)
                {
                    qry = from paydata in qry
                          join bill in Bill on paydata.BillNo equals bill.Id
                          join us in UnitSummary on bill.UnitId equals us.id 
                          where us.divisionid == empDetail.divisionid
                          select paydata;
                }

                var authtime = DateTime.Now;
                var rows = qry.ToList();

                foreach (var pd in rows)
                {
                    pd.Authenticated = true;
                    pd.AuthAt = authtime;
                    pd.AuthBy = emp.loginname;
                }
                PaymentDetail.UpdateRange(rows);
                this.SaveChanges();
            }
            catch (Exception ex)
            {
                result = "Failed :" + ex.Message;
            }
            return result;
        }
        public string CancelPayment(long PaymentId)
        {
            var result = "Success";
            try
            {
                var userid = Context.GetUser();
                var emp = (from empl in EmployeeLoginMapping where empl.employeeid == userid select empl).FirstOrDefault();
               


                var payment = (from pd in PaymentDetail
                               where pd.Id == PaymentId
                               select pd).FirstOrDefault();
                if (payment != null)
                {
                    var bg = (from b in Bill
                                where b.Id == payment.BillNo
                                join us in UnitSummary on b.UnitId equals us.id 
                                join bgd in BillGroupDetail on 
                                b.MonthYear equals bgd.BillMonth.ToString("00") + bgd.BillYear.ToString()
                                where bgd.DivisionId == us.divisionid &&  bgd.BillGroupId == us.billgroupid
                                select bgd).FirstOrDefault();
                    if (bg != null && bg.Status != "Closed")
                    {
                        payment.Canceled = true;
                        payment.CanceledAt = DateTime.Now;
                        payment.CanceledBy = emp.loginname;
                        PaymentDetail.Update(payment);
                        this.SaveChanges();
                    }
                    else
                        result = "Failed: BillGroup Already Closed";
                }
            }
            catch (Exception ex)
            {

                result = "Failed " + ex.Message;
            }
     
            return result;
        }
        public PagedResponse<PaymentProcess> Process(PagedData<ProcessInput> pagedInput)
        {
            bool AllRecords = false;
            var input = pagedInput.Data;
            var result = new PagedResponse<PaymentProcess>();
            var start = pagedInput.PageNumber.HasValue ? pagedInput.PageNumber.Value : 1;
            var next = pagedInput.NumberOfRecords.HasValue ? pagedInput.NumberOfRecords.Value : 20;
            AllRecords = (next == -1);

            start = (start - 1) * next;

            var bgd = (from bg in BillGroupDetail
                       where bg.Id == input.GroupId
                       select bg).FirstOrDefault();
            if (bgd == null)
                throw new Exception("Bill Group Not Generated");

            var rec = from pp in PaymentProcess
                      join bill in Bill on pp.BillNo equals bill.Id
                      join us in UnitSummary on bill.UnitId equals us.id
                      where bill.MonthYear == input.MonthYear &&
                      us.billgroupid == bgd.BillGroupId && 
                      us.divisionid == input.DivisionId
                      select pp;
            if (rec.Count() == 0)
            {
                processPayment(input);
                rec = from pp in PaymentProcess
                      join bill in Bill on pp.BillNo equals bill.Id
                      join us in UnitSummary on bill.UnitId equals us.id
                      where bill.MonthYear == input.MonthYear &&
                      us.billgroupid == bgd.BillGroupId &&
                      us.divisionid == input.DivisionId
                      select pp;
            }
            result.TotalRecords = rec.Count();
            result.Data = (AllRecords) ? rec : rec.Skip(start).Take(next);
            return result;
        }

        private void processPayment(ProcessInput input)
        {
            var userid = Context.GetUser();
            var emp = (from empl in Employee where empl.employeeid == userid select empl).FirstOrDefault();
            var emplog = (from empl in EmployeeLoginMapping where empl.employeeid == userid select empl).FirstOrDefault();
            if (emp.divisionid != null)
            {
                var bgd = (from bg in BillGroupDetail
                           where bg.Id == input.GroupId
                           select bg).FirstOrDefault();
                if (bgd == null)
                    throw new Exception("Bill Group Not Generated");
                var now = DateTime.Now;
                var qry = from bill in Bill
                          join us in UnitSummary on bill.UnitId equals us.id
                          where us.divisionid == emp.divisionid &&
                          us.billgroupid == bgd.BillGroupId &&
                          bill.MonthYear == input.MonthYear
                          join pay in PaymentDetail
                          on bill.Id equals pay.BillNo into pd
                          from p in pd.DefaultIfEmpty()
                              //from p in pd.Where(o=>o.Canceled==false).DefaultIfEmpty()
                              //where  p.Canceled == false
                          group new { Bill = bill, Pay = p } by bill.Id into g
                          select new PaymentProcess
                          {
                              Amount = g.First().Bill.TotalAmount,
                              BillNo = g.First().Bill.Id,
                              Paid = g.Sum(p => p.Pay == null ? 0 : p.Pay.Canceled ?0 : p.Pay.Amount),
                          };
                var qryLst = qry.ToList();
                foreach (var item in qryLst)
                {
                    item.Balance = Convert.ToDouble(item.Paid)-item.Amount;
                    item.OverPay = item.Balance > 0;
                    item.ProcessedAt = DateTime.Now;
                    item.ProcessedBy = emplog.loginname;
                }
                PaymentProcess.AddRange(qryLst);
                
                bgd.Status = "Closed";
                BillGroupDetail.Update(bgd);
                this.SaveChanges();



            }
        }
    }
}
