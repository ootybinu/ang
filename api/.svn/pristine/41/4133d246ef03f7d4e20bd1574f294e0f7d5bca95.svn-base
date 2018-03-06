using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterAMR.BusinessModels.User;

namespace WaterAMR.BusinessModels.Billing
{
    public class Bill
    {
        public long Id { get; set; }
        public string MonthYear { get; set; }
        public double UnitId { get; set; }
        public double FirstReading { get; set; }
        public double LastReading { get; set; }
        public double Consumption { get; set; }
        public double WaterCharge { get; set; }
        public double MeterCharge { get; set; }
        public double SanitaryCharge { get; set; }
        public double BorewellCharge { get; set; }
        public double OtherCharge { get; set; }
        public double Arrears { get; set; }
        public double InterestOnArrears { get; set; }
        public double TotalAmount { get; set; }
        public DateTime AddedAt { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? BillDate { get; set; }
        public DateTime FirstDate { get; set; }
        public DateTime LastDate { get; set; }
        public int MissingDays { get; set; }
        public double ExtraPaid { get; set; }
    }
    public class BillDetail
    {
        public BillGroupDetail BillGroupDetail { get; set; }
        public Bill Bill { get; set; }
        public UnitSummary.UnitSummary UnitSummary { get; set; }
        public employee Employee { get; set; }
        public string SubDivision { get; set; }

    }
    public class BGInput
    {
        public long DivisionId { get; set; }
    }

    public class BillGroup
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public double StartDay { get; set; }
        public Boolean BiMonthly { get; set; }
        public DateTime AddedAt { get; set; }
        public Boolean BiMonthlyEven { get; set; }
        public int DueDays { get; set; }
        public long DivisionId { get; set; }
    }
    public class BillGroupDetail
    {
        public long Id { get; set; }
        public int BillMonth { get; set; }
        public int BillYear { get; set; }
        public long DivisionId { get; set; }
        public long? SubDivisionId { get; set; }
        public long BillGroupId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime BillDate { get; set; }
        public DateTime DueDate { get; set; }
        public string Status { get; set; }
    }
    public class BillGroupDetailVM
    {
        public long Id { get; set; }
        public int BillMonth { get; set; }
        public int BillYear { get; set; }
        public long DivisionId { get; set; }
        public long? SubDivisionId { get; set; }
        public long BillGroupId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime BillDate { get; set; }
        public DateTime DueDate { get; set; }
        public string Status { get; set; }
        public string GroupCode { get; set; }
        public string GroupDescription { get; set; }
    }
}
