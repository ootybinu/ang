using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using WaterAMR.DataRepository;
using WaterAMR.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using WaterAMR.DataModels.Realtime;
using WaterAMR.DataModels.UnitSummary;
using WaterAMR.DataModels.Billing;
using WaterAMR.DataModels;
using WaterAMR.DataModels.User;
using WaterAMR.DataModels.Organization;

namespace WaterAMR.DataAccess
{
    public class BillingRepository: DataStore, IBillingRepository
    {
        DbSet<UnitConsumptionDetail> UnitConsumptionDetails { get; set; }
        DbSet<UnitSummary> UnitSummary{ get; set; }
        DbSet<TariffMaster> TariffMaster { get; set; }
        DbSet<employee> Employee { get; set; }
        DbSet<Bill> Bills { get; set; }
        DbSet<BillGroup> BillGroup { get; set; }
        DbSet<Organization> Organization { get; set; }
        DbSet<BillGroupDetail> BillGroupDetail { get; set; }
        DbSet<DataModels.Payment.PaymentProcess> PaymentProcess { get; set; }
        public BillingRepository(IConfiguration configHelper) : base(configHelper)
        {
        }

        public PagedResponse<BillDetail> GetBills(PagedData<BillFilter> pagedInput) {
            var result = new PagedResponse<BillDetail>();
            bool AllRecords = false;
            var input = pagedInput.Data;
            var start = pagedInput.PageNumber.HasValue ? pagedInput.PageNumber.Value : 1;
            var next = pagedInput.NumberOfRecords.HasValue ? pagedInput.NumberOfRecords.Value : 20;
            AllRecords = (next == -1);
            start = (start - 1) * next;

            var qry = from bill in this.Bills
                      join us in this.UnitSummary on bill.UnitId equals us.id
                      join emp in this.Employee on us.consumerid equals emp.employeeid into emprec
                      from em in emprec.DefaultIfEmpty()
                      //join org in this.Organization on us.divisionid equals org.organizationid 
                      where bill.MonthYear == input.MonthYear
                      select new BillDetail { Bill = bill, Employee = em, UnitSummary = us, SubDivision = "" };//org.organizationname };

            if (!string.IsNullOrEmpty(input.DivisionId) )
                qry = qry.Where(ob => ob.UnitSummary.divisionid == Convert.ToInt32(input.DivisionId));
            if (!string.IsNullOrEmpty(input.SubDivisionId))
                qry = qry.Where(ob => ob.UnitSummary.subdivisionid == Convert.ToInt32(input.SubDivisionId));
            if (!string.IsNullOrEmpty(input.LocationId ))
                qry = qry.Where(ob => ob.UnitSummary.locationid == Convert.ToInt32(input.LocationId));
            if (!string.IsNullOrEmpty(input.ServiceId))
                qry = qry.Where(ob => ob.UnitSummary.servicestnid == Convert.ToInt32(input.ServiceId));

            result.TotalRecords = qry.Count();

            if (AllRecords)
                result.Data = qry;
            else
                result.Data = qry .Skip(start).Take(next);
            return result;
        }
        public PagedResponse<BillDetail> GetBillsforPrint(PagedData<BillGenerateInput> pagedInput)
        {
            var result = new PagedResponse<BillDetail>();
            bool AllRecords = false;
            var input = pagedInput.Data;
            var start = pagedInput.PageNumber.HasValue ? pagedInput.PageNumber.Value : 1;
            var next = pagedInput.NumberOfRecords.HasValue ? pagedInput.NumberOfRecords.Value : 20;
            AllRecords = (next == -1);
            start = (start - 1) * next;

            var qry = from bill in this.Bills
                      join us in this.UnitSummary on bill.UnitId equals us.id
                      join emp in this.Employee on us.consumerid equals emp.employeeid into emprec
                      from em in emprec.DefaultIfEmpty()
                          //join org in this.Organization on us.divisionid equals org.organizationid 
                      where bill.MonthYear == input.MonthYear
                      select new BillDetail { Bill = bill, Employee = em, UnitSummary = us, SubDivision = "" };//org.organizationname };

            if (!string.IsNullOrEmpty(input.DivisionId))
                qry = qry.Where(ob => ob.UnitSummary.divisionid == Convert.ToInt32(input.DivisionId));
            if (!string.IsNullOrEmpty(input.SubDivisionId))
                qry = qry.Where(ob => ob.UnitSummary.subdivisionid == Convert.ToInt32(input.SubDivisionId));
            //if (!string.IsNullOrEmpty(input.LocationId))
            //    qry = qry.Where(ob => ob.UnitSummary.locationid == Convert.ToInt32(input.LocationId));
            //if (!string.IsNullOrEmpty(input.ServiceId))
            //    qry = qry.Where(ob => ob.UnitSummary.servicestnid == Convert.ToInt32(input.ServiceId));

            result.TotalRecords = qry.Count();

            if (AllRecords)
                result.Data = qry;
            else
                result.Data = qry.Skip(start).Take(next);
            return result;
        }
        public PagedResponse<BillGroup> GetBillGroupMaster(PagedData<BGInput> pagedInput) {
            var result = new PagedResponse<BillGroup>();
            bool AllRecords = false;
            var input = pagedInput.Data;
            var start = pagedInput.PageNumber.HasValue ? pagedInput.PageNumber.Value : 1;
            var next = pagedInput.NumberOfRecords.HasValue ? pagedInput.NumberOfRecords.Value : 20;
            AllRecords = (next == -1);
            start = (start - 1) * next;
            var qry = from bg in BillGroup
                      where bg.DivisionId == input.DivisionId
                      select bg;
            result.TotalRecords = qry.Count();
            if (AllRecords)
                result.Data = qry;
            else
                result.Data = qry.Skip(start).Take(next);
            return result;
        }
        public BillDetail GetBill(int BillNo)
        {
            var qry = from bill in this.Bills
                      join us in this.UnitSummary on bill.UnitId equals us.id
                      join bgd in BillGroupDetail on us.billgroupid equals bgd.BillGroupId
                      where bgd.BillMonth.ToString("00")+ bgd.BillYear.ToString() == bill.MonthYear && 
                            bgd.DivisionId == us.divisionid 
                      join emp in this.Employee on us.consumerid equals emp.employeeid into emprec
                      from em in emprec.DefaultIfEmpty()
                          //join org in this.Organization on us.divisionid equals org.organizationid 
                      where bill.Id == BillNo
                      select new BillDetail { Bill = bill, Employee = em, UnitSummary = us, SubDivision = "", BillGroupDetail= bgd };//org.organizationname };
            return qry.FirstOrDefault();

        }
        public string UpdateBillGroupMaster(BillGroup input) {
            string result = "Success";
            if (input.Id == 0)
            {
                input.AddedAt = DateTime.Now;
                BillGroup.Add(input);

                SaveChanges();
                return result;
            }
            var bgUpdate = (from bg in BillGroup
                            where bg.Id == input.Id
                            select bg).FirstOrDefault();
            if (bgUpdate != null)
            {
                bgUpdate.Description = input.Description;
                bgUpdate.Code = input.Code;
                bgUpdate.BiMonthly = input.BiMonthly;
                bgUpdate.BiMonthlyEven = input.BiMonthlyEven;
                bgUpdate.StartDay = input.StartDay;
                bgUpdate.DueDays = input.DueDays;
                bgUpdate.AddedAt = DateTime.Now;
                BillGroup.Update(bgUpdate);
                SaveChanges();
            }
            return result;
        }
        public string DeleteBillGroupMaster(BillGroup input) {
            string result = "Success";
            var unitsCount = (from un in UnitSummary
                              where un.billgroupid == input.Id
                              select un).Count();
            if (unitsCount > 0)
                result = "Units are linked to this Bill Group, Please unlink them before deleting.";
            else
            {
                var bgRemove = (from bg in BillGroup where bg.Id == input.Id
                               select bg).FirstOrDefault();
                if (bgRemove != null)
                {
                    BillGroup.Remove(bgRemove);
                    SaveChanges();
                }
            }

            return result;
        }
        public PagedResponse<BillGroupDetailVM> GetBillGroupDetails(PagedData<BillGenerateInput> pagedInput)
        {
            var result = new PagedResponse<BillGroupDetailVM>();
            bool AllRecords = false;
            var input = pagedInput.Data;
            var start = pagedInput.PageNumber.HasValue ? pagedInput.PageNumber.Value : 1;
            var next = pagedInput.NumberOfRecords.HasValue ? pagedInput.NumberOfRecords.Value : 20;
            AllRecords = (next == -1);
            start = (start - 1) * next;

            var month = Convert.ToInt32(input.MonthYear.Substring(0, 2));
            var year = Convert.ToInt32(input.MonthYear.Substring(2));

            //var qry = from bgd in BillGroupDetail
            //          where bgd.DivisionId == Convert.ToInt32(input.DivisionId) &&
            //         // bgd.BillGroupId == input.GroupId && 
            //          bgd.BillMonth == month && 
            //          bgd.BillYear == year
            //          select bgd;
            //if (!qry.Any())
            //{
                GenerateBillGroupDetail(input, month, year);
                var qry = from bgd in BillGroupDetail
                      where bgd.DivisionId == Convert.ToInt32(input.DivisionId) &&
                     // bgd.BillGroupId == input.GroupId &&
                      bgd.BillMonth == month &&
                      bgd.BillYear == year
                      select bgd;
            //}
            result.TotalRecords = qry.Count();
            var vm = from res in qry
                     join bg in BillGroup
                     on res.BillGroupId equals bg.Id
                     select new BillGroupDetailVM
                     {
                         Id = res.Id,
                         BillDate = res.BillDate,
                         BillGroupId = res.BillGroupId,
                         BillMonth = res.BillMonth,
                         BillYear = res.BillYear,
                         DivisionId = res.DivisionId,
                         DueDate = res.DueDate,
                         EndDate = res.EndDate,
                         StartDate = res.StartDate,
                         Status = res.Status,
                         SubDivisionId = res.SubDivisionId,
                         GroupCode = bg.Code,
                         GroupDescription = bg.Description
                     };
            result.Data = vm;

            if (AllRecords)
                result.Data = vm;
            else
                result.Data = vm.Skip(start).Take(next);
            return result;
        }

        public List<KeyValuePair<long, string>> GetBillGroupList(BillGenerateInput input) {
            var month = Convert.ToInt32(input.MonthYear.Substring(0, 2));
            var year = Convert.ToInt32(input.MonthYear.Substring(2));

            var result = from bg in BillGroup
                         join bgd in BillGroupDetail
                         on bg.Id equals bgd.BillGroupId
                         where bgd.DivisionId == Convert.ToInt32(input.DivisionId) &&
                         bgd.BillYear == year &&
                         bgd.BillMonth == month
                         select new KeyValuePair<long, string>(bgd.Id, bg.Code);
            return result.ToList();

        }
        public BillGroupDetailVM GetBillGroup(long billgroupId) {
            var result = from bg in BillGroup
                         join bgd in BillGroupDetail
                            on bg.Id equals bgd.BillGroupId
                         where bgd.Id == billgroupId
                         select new BillGroupDetailVM
                         {
                             Id = bgd.Id,
                             BillDate = bgd.BillDate,
                             BillGroupId = bgd.BillGroupId,
                             BillMonth = bgd.BillMonth,
                             BillYear = bgd.BillYear,
                             DivisionId = bgd.DivisionId,
                             DueDate = bgd.DueDate,
                             EndDate = bgd.EndDate,
                             StartDate = bgd.StartDate,
                             Status = bgd.Status,
                             SubDivisionId = bgd.SubDivisionId,
                             GroupCode = bg.Code,
                             GroupDescription = bg.Description
                         };
            return result.FirstOrDefault();
        }
        private void GenerateBillGroupDetail(BillGenerateInput input, int month, int year)
        {
            var bgids = (from us in UnitSummary
                         where us.divisionid == Convert.ToInt32(input.DivisionId)
                         select us.billgroupid).Distinct();
            var bgs = from bg in BillGroup
                      join bgid in bgids on bg.Id equals bgid
                      select bg;
            var bglist = new List<BillGroupDetail>();
            foreach (var bg in bgs)
            {
                var bgdetail = from bgd in BillGroupDetail
                               where bgd.BillGroupId == bg.Id &&
                               bgd.BillMonth == month && bgd.BillYear == year
                               select bgd;
                if (!bgdetail.Any()) { 

                var addThis = false;
                DateTime startDate = new DateTime(year, month, (int)bg.StartDay);
                DateTime endDate = startDate;// = startDate.AddMonths(2);
                DateTime billDate = startDate.AddDays(1);
                DateTime dueDate = billDate.AddDays(bg.DueDays);

                if (bg.BiMonthly && month % 2 == (bg.BiMonthlyEven ? 0 : 1))
                {
                    addThis = true;
                    endDate = startDate.AddMonths(2).AddDays(-1);
                }
                if (!bg.BiMonthly)
                {
                    addThis = true;
                    endDate = startDate.AddMonths(1).AddDays(-1);
                }
                if (addThis)
                {
                    bglist.Add(new DataModels.Billing.BillGroupDetail()
                    {
                        BillDate = billDate,
                        BillGroupId = bg.Id,
                        BillMonth = month,
                        BillYear = year,
                        DivisionId = Convert.ToInt32(input.DivisionId),
                        DueDate = dueDate,
                        StartDate = startDate,
                        EndDate = endDate,
                        Status = "Created"
                    });
                }
            } }
            if (bglist.Count >0)
                BillGroupDetail.AddRange(bglist);
            this.SaveChanges();
        }

        public string GenerateBillBGWise(long BillGroupDetailId) {
            var result = "Success";
            var billsToAdd = new List<Bill>();
            var bgDetail = GetBillGroup(BillGroupDetailId);
            var monthYear = bgDetail.BillMonth.ToString("00") + bgDetail.BillYear.ToString();
            var units = from unit in UnitSummary
                        where unit.billgroupid == bgDetail.BillGroupId &&
                        unit.divisionid == bgDetail.DivisionId
                        select unit;
            var exist = (from bill in Bills
                         join ui in units
                         on bill.UnitId equals ui.id
                         where bill.MonthYear == monthYear
                         select ui).Any();
            if (exist)
                return "Already Bill Generated for this Period.";
            foreach (var unit in units.ToList())
            {
               billsToAdd.Add( GenerateBillForUnit(bgDetail,unit,  monthYear ));
            }
            Bills.AddRange(billsToAdd);
            SaveChanges();
            var bgd = (from bg in BillGroupDetail
                      where bg.Id == BillGroupDetailId
                      select bg).FirstOrDefault();
            bgd.Status = "Generated";
            BillGroupDetail.Update(bgd);
            SaveChanges();


            return result;
        }
        public string UpdateBillGroupItem(BillGroupDetail input) {
            var result = "Success";
            try
            {
                var item = (from bg in BillGroupDetail
                            where bg.Id == input.Id
                            select bg).FirstOrDefault();
                if (item != null)
                {
                    item.DueDate = input.DueDate;
                    item.BillDate = input.BillDate;
                    BillGroupDetail.Update(item);
                    this.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                return "Failed :" + ex.Message;
            }
            return result;

        }
        private Bill GenerateBillForUnit(BillGroupDetailVM bgDetail, UnitSummary unit, string monthYear)
        {
            var missingDays = 0;
            double extra = 0;
            double arrear = 0; 
                 var tmissingDays = (from oldBill in Bills
                                   where oldBill.UnitId == unit.id &&
                                   oldBill.AddedAt < bgDetail.BillDate
                                   orderby oldBill.AddedAt descending
                                   select oldBill).FirstOrDefault();
                missingDays = tmissingDays == null ? 0 : tmissingDays.MissingDays;
            if (tmissingDays != null)
            {
                var payprocess = (from pp in PaymentProcess
                                  where pp.BillNo == tmissingDays.Id
                                  select pp).FirstOrDefault();
                extra = payprocess == null ? 0 : payprocess.Balance >0  ? payprocess.Balance: 0;
                arrear = payprocess == null ? 0 : payprocess.Balance < 0 ? Math.Abs( payprocess.Balance) : 0;
            }
            var billPeriodData = from uc in UnitConsumptionDetails
                                 where uc.unitid == unit.id &&
                                 uc.daterecorded >= bgDetail.StartDate.AddDays(-missingDays) &&
                                 uc.daterecorded <= bgDetail.EndDate
                                 orderby uc.daterecorded
                                 select uc;
            var firstDay= billPeriodData.FirstOrDefault();
            var lastDay= billPeriodData.LastOrDefault();
            
            var consumption = firstDay==null?0: lastDay.consumptioninmcube - firstDay.consumptioninmcube;
            var bill = new Bill
            {
                MonthYear = monthYear,
                UnitId = unit.id,
                BillDate = bgDetail.BillDate,
                DueDate = bgDetail.DueDate,
                FirstReading = firstDay==null?0: firstDay.consumptioninmcube,
                LastReading = lastDay==null?0:lastDay.consumptioninmcube,
                Consumption = consumption,
                FirstDate = firstDay==null?bgDetail.StartDate: firstDay.daterecorded,
                LastDate = lastDay==null?bgDetail.EndDate: lastDay.daterecorded,
                MissingDays =lastDay==null?0: lastDay.daterecorded == DateTime.MinValue ? 0 : (lastDay.daterecorded - firstDay.daterecorded).Days,
                Arrears = arrear, 
                ExtraPaid = extra, 
                AddedAt = DateTime.Now
            };
            bill = CalculateTariff(unit.unitid, consumption, unit.meterbillingtype, bill, bgDetail.BillYear, bgDetail.DivisionId);
            return bill;

        }

        public string GenerateBill(BillGenerateInput input)
        {
            var month =Convert.ToInt32(  input.MonthYear.Substring(0, 2));
            var year = Convert.ToInt32(input.MonthYear.Substring(2));
            var lastDay = DateTime.DaysInMonth(year, month);
            var startDate = Convert.ToDateTime($"01/{month}/{year}");
            var stopDate = Convert.ToDateTime($"{lastDay}/{month}/{year}");
            var units = from us in UnitSummary select us;
            if (!string.IsNullOrEmpty(input.DivisionId))
                units = units.Where(ob => ob.divisionid == Convert.ToInt32(input.DivisionId));
            if (!string.IsNullOrEmpty(input.SubDivisionId))
                units = units.Where(ob => ob.subdivisionid == Convert.ToInt32(input.SubDivisionId));
            if (!string.IsNullOrEmpty(input.Category))
                units = units.Where(ob => ob.meterbillingtype == input.Category);
           var  unitids = (from us in units
                     select us.unitid).Distinct().ToList();
            var exist = (from bill in Bills
                         join ui in units
                         on bill.UnitId equals ui.id
                         where bill.MonthYear == input.MonthYear 
                         select ui).Any();
            if (exist)
                return "Already Bill Generated for this Period.";

            //join uc in UnitConsumptionDetails
            //on us.id equals uc.unitid
            //where us.meterbillingtype == "AM" 
            //&& 
            //uc.DateRecorded >= startDate && 
            //uc.DateRecorded <= stopDate
            //select us.unitid).Distinct().ToList();
            foreach (string unitid in unitids)
            {
                GenerateBillForUnitId(input,  unitid,month, year);
            }
            return "Success";
        }
        //public BillGroupResult Validate(BillGenerateInput input) {

        //    var bg = (from BgItem in BillGroup
        //              where BgItem.Id == input.GroupId
        //              select BgItem).FirstOrDefault();
        //    if (bg != null)
        //    {
        //        var month = bg.BiMonthly ? 2 : 1;

        //    }
        //    return null;
        //}
        //public string AddBillGroupDetail(BillGenerateInput input)
        //{
        //    var month = Convert.ToInt32(input.MonthYear.Substring(0, 2));
        //    var year = Convert.ToInt32(input.MonthYear.Substring(2));
        //    var lastDay = DateTime.DaysInMonth(year, month);

        //    var bg = (from BgItem in BillGroup
        //              where BgItem.Id == input.GroupId
        //              select BgItem).FirstOrDefault();
        //    if (bg != null)
        //    {

        //    }

        //    return "";
        //}
        private void GenerateBillForUnitId(BillGenerateInput input,  string unitid, int month, int year)
        {
            //var uid = (from us in UnitSummary
            //           where us.unitid == unitid
            //           select us.id).FirstOrDefault();
            var unit = (from us in UnitSummary
                       where us.unitid == unitid
                       select us).FirstOrDefault();
            var uid = unit.id;
            var unitcategory = unit.meterbillingtype;

            //var unitcategory = (from us in UnitSummary
            //           where us.unitid == unitid select us.meterbillingtype)
            //           .FirstOrDefault();
            var billgroup = (from bg in BillGroup
                            where bg.Id == unit.billgroupid
                            select bg).FirstOrDefault();

            var startDate = Convert.ToDateTime($"{billgroup.StartDay}/{month}/{year}");

            var stopDate = GetLastDay(month, year,(int)billgroup.StartDay,   billgroup.BiMonthly);
            var missingDays = (from oldBill in Bills
                                     where oldBill.UnitId == uid
                                     orderby oldBill.AddedAt descending
                                     select oldBill.MissingDays).FirstOrDefault();


            if (billgroup.BiMonthly) {
                if (billgroup.BiMonthlyEven && month%2==1)
                return;
                if (!billgroup.BiMonthlyEven && month % 2 == 0)
                    return;
            }

            var firstConsumption = (from uc in UnitConsumptionDetails
                                    where uc.unitid== uid
                                    && uc.daterecorded >= startDate.AddDays(-missingDays)
                                    && uc.daterecorded <= stopDate
                                    orderby uc.daterecorded ascending
                                    select uc.consumptioninmcube).FirstOrDefault();
            var firstDate = (from uc in UnitConsumptionDetails
                             where uc.unitid == uid
                             && uc.daterecorded >= startDate
                             select uc.daterecorded).Min();

            var lastConsumption = (from uc in UnitConsumptionDetails
                                   where uc.unitid == uid
                                   && uc.daterecorded >= startDate.AddDays(- missingDays)
                                   && uc.daterecorded <= stopDate
                                   orderby uc.daterecorded descending
                                   select uc.consumptioninmcube).FirstOrDefault();
            var lastDate = (from uc in UnitConsumptionDetails
                            where uc.unitid == uid
                            && uc.daterecorded >= startDate
                            && uc.daterecorded <= stopDate
                            select uc.daterecorded).Max();
            
            var consumption = lastConsumption - firstConsumption;
            var bill = new Bill();
            bill.MonthYear = input.MonthYear;
            bill.UnitId = uid;
            bill.FirstReading = firstConsumption;
            bill.LastReading = lastConsumption;
            bill.Consumption = consumption;
            bill = CalculateTariff(unitid, consumption, unitcategory, bill, year, Convert.ToInt32( input.DivisionId));
            bill.BillDate = input.BillDate; //DateTime.Now;
            bill.DueDate = input.DueDate;//bill.AddedAt.AddDays(15);
            bill.FirstDate = firstDate;
            bill.LastDate = lastDate;
            bill.MissingDays = lastDate==DateTime.MinValue ?0: (stopDate - lastDate).Days;
            bill.AddedAt = DateTime.Now;
            Bills.Add(bill);
            this.SaveChanges();
        }

        private DateTime GetLastDay(int month, int year, int startDay, bool biMonthly)
        {
            DateTime dt = new DateTime(year, month, startDay);
            dt = biMonthly ? dt.AddMonths(2).AddDays(-1) : dt.AddMonths(1).AddDays(-1);
            return dt;
        }

        private Bill CalculateTariff(string unitid, double consumption, string category, Bill bill, int year, long divisionId)
        {
            var rec = (from tariff in TariffMaster
                      where consumption >= tariff.SlabMin
                      && consumption <= tariff.SlabMax
                      && tariff.CategoryId == category
                      &&  tariff.Year == year
                      && tariff.DivisionId == divisionId
                      select tariff).FirstOrDefault() ;
            bill.SanitaryCharge = (rec.SanitaryType == "Rs") ? rec.Sanitary : (rec.Sanitary * consumption / 100);
           // bill.Arrears = 0;
            bill.BorewellCharge = rec.Borewell;
            bill.MeterCharge = rec.MeterCost;
            bill.WaterCharge = (consumption - rec.SlabMin) * rec.Tariff;
            var allRecords = from tariff in TariffMaster
                             where tariff.CategoryId == category
                             && tariff.SlabMax < rec.SlabMin  // tariff.Id < rec.Id
                             select tariff;

            foreach (var tarif in allRecords)
            {
                bill.WaterCharge += (tarif.SlabMax - tarif.SlabMin) * tarif.Tariff;
            }
            bill.TotalAmount = bill.SanitaryCharge + bill.BorewellCharge + bill.MeterCharge + bill.OtherCharge + bill.WaterCharge + bill.Arrears -bill.ExtraPaid;
            return bill;
        }
    }
}
