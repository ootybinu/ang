using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WaterAMR.BusinessModels.Payment
{
    public class PaymentDetail
    {
        public long Id { get; set; }
        public long BillNo { get; set; }
        public decimal Amount { get; set; }
        public string ModeOfPay { get; set; }
        public string ChequeNo { get; set; }
        public string BankName { get; set; }
        public string BranchName { get; set; }
        public string BankAddress { get; set; }
        public string AddedBy { get; set; }
        public DateTime AddedAt { get; set; }
        public bool Canceled { get; set; }
        public string CanceledBy { get; set; }
        public DateTime? CanceledAt { get; set; }
        public bool Authenticated { get; set; }
        public string AuthBy { get; set; }
        public DateTime? AuthAt { get; set; }


    }
    public class PaymentResultVM
    {
        public IEnumerable<PaymentDetail> Payments { get; set; }
        public decimal TotalAmount { get; set; }
    }
    public class PaymentAuthenticationVM
    {
        public IEnumerable<PaymentAuthenticaionResult> AuthenticationData { get; set; }
        public decimal TotalAmount { get; set; }
        public bool Authenticated { get; set; }

    }
    public class PaymentAuthenticaionResult
    {
        public Billing.Bill Bill { get; set; }
        public PaymentDetail Payment { get; set; }
    }
    public class PaymentProcess
    {
        public long Id { get; set; }
        public long BillNo { get; set; }
        public double Amount { get; set; }
        public decimal Paid { get; set; }
        public double Balance { get; set; }
        public bool OverPay { get; set; }
        public string ProcessedBy { get; set; }
        public DateTime ProcessedAt { get; set; }
    }
    public class ProcessInput {
        public long DivisionId { get; set; }
        public string MonthYear { get; set; }
        public long GroupId { get; set; }
    }

}
