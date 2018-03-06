using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WaterAMR.DataModels.User;

namespace WaterAMR.DataModels.Billing
{
    [Table("bills")]
    public class Bill
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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

    [Table("billgroup")]
    public class BillGroup
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
        public class BillDetail
    {
        public BillGroupDetail BillGroupDetail { get; set; }
        public Bill Bill{ get; set; }
        public UnitSummary.UnitSummary UnitSummary { get; set; }
        public employee  Employee { get; set; }
        public string SubDivision { get; set; }
    }
    public class BGInput
    {
        public long DivisionId { get; set; }
    }

    public class BillGenerateInput
    {
        public string MonthYear { get; set; }
        public string Category { get; set; }
        public DateTime BillDate { get; set; }
        public DateTime DueDate { get; set; }
        public string DivisionId { get; set; }
        public string SubDivisionId { get; set; }
        public int GroupId { get; set; }
    }
    public class BillGroupResult
    {
        public bool Valid { get; set; }
        public string Message { get; set; }
        public DateTime BillDate { get; set; }
        public DateTime DueDate { get; set; }
    }


    [Table("billgroupdetail")]
    public class BillGroupDetail {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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