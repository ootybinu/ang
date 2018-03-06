using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WaterAMR.DataModels.UnitSummary
{
    [Table("unit_summary")]
    public class UnitSummary
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }
        public string unitid { get; set; }
        public DateTime installon { get; set; }
        public string pipesize { get; set; }
        public string pipesizenew { get; set; }
        public decimal? totalflow { get; set; }
        public decimal? averageflow { get; set; }
        public Int32 subdivisionid { get; set; }
        public Int32 divisionid { get; set; }
        public Int32 servicestnid { get; set; }
        public Int32 locationid { get; set; }
        public string divisionhead { get; set; }
        public string subdivisionhead { get; set; }
        public DateTime? messagetime { get; set; }
        public string mobilenumberofunit { get; set; }
        public decimal metercalibfactor { get; set; }
        public DateTime metercalibrationdate { get; set; }
        public string batterylimitvalue { get; set; }
        public decimal initialmeterreading { get; set; }
        public bool considerinitmtrfornextsms { get; set; }
        public decimal ltrperpulse { get; set; }
        public string fieldpicture { get; set; }
        public decimal? tariffperltr { get; set; }
        public string mobilenumberofalarmmessagerecipient1 { get; set; }
        public string mobilenumberofalarmmessagerecipient2 { get; set; }
        public string mobilenumberofalarmmessagerecipient3 { get; set; }
        public string mailidofalarmmessagerecipient1 { get; set; }
        public string mailidofalarmmessagerecipient2 { get; set; }
        public string mailidofalarmmessagerecipient3 { get; set; }
        public decimal? latitude { get; set; }
        public decimal? longitude { get; set; }
        public Int64? consumerid { get; set; }
        public string consumeraddress { get; set; }
        public string consumercontactnumber { get; set; }
        public string meterslno { get; set; }
        public string oemname { get; set; }
        public string metertype { get; set; }
        public string meterflowtype { get; set; }
        public string meterbillingtype { get; set; }
        public string gsmsignalstrength { get; set; }
        public string metermodelnumber { get; set; }
        public string modeofcommuniction { get; set; }
        public string gprstype { get; set; }
        public string gprstypeurl { get; set; }
        public string communicationperiod { get; set; }
        public DateTime? rechargedate { get; set; }
        public string serviceprovider { get; set; }
        public string daysofwaterflow { get; set; }
        public string fromwaterflow { get; set; }
        public string towaterflow { get; set; }
        public decimal? averagepressure { get; set; }
        public decimal? averageflowrate { get; set; }
        public bool active { get; set; }
        public long billgroupid { get; set; }
    }
    [Table("unitsconsumptiondetails")]
    public class UnitsConsumptionDetails
    {
        [Key]
        public long id { get; set; }
        public DateTime daterecorded { get; set; }
        public long unitid { get; set; }
        public decimal consumptioninmcube { get; set; }
        public decimal dayconsumption { get; set; }
        public DateTime addedat { get; set; }
        public long messagedataid { get; set; }

    }
    [Table("ftp_data")]
    public class ftp_data
    {
        [Key]
        public long id { get; set; }
        public long unitid { get; set; }
        public DateTime readdatetime { get; set; }
        public decimal flowvalue { get; set; }
        public decimal totalizer1 { get; set; }
        public decimal totalizer2 { get; set; }
        public decimal totalizer3 { get; set; }
        public string analoginput1value { get; set; }
        public string analoginput2value { get; set; }
        public string battery_capacity { get; set; }
        public string alarms { get; set; }
        public DateTime transmissiontimefromprotocol { get; set; }
    }

    [Table("message_data")]
    public class message_data
    {
        [Key]
        public long id { get; set; }
        public long unitid { get; set; }
        public string hourlydataoflast24hrs { get; set; }
        public decimal cumconsumpofprevday { get; set; }
        public decimal cumconsumpofprevtoprevday { get; set; }
        public Int16 tamperstatus { get; set; }
        public decimal batteryvoltage { get; set; }
        public decimal temperature { get; set; }
        public decimal? last24hrsreversepulsecount { get; set; }
        public DateTime date { get; set; }
        public TimeSpan time { get; set; }
    }
    [Table("message_rejected")]
    public class MessageRejected
    {
        [Key]
        public long id { get; set; }
        public string Message { get; set; }
        public string Sentby { get; set; }
        public DateTime SentDate { get; set; }
        public TimeSpan SentTime { get; set; }
        public string SmsHeader { get; set; }
        public string RejectReason { get; set; }
    }
    public class MessageRejectedInput { }
    //[Table("billgroup")]
    //public class BillGroup
    //{
    //    [Key]
    //    public long id { get; set; }
    //    public string Code { get; set; }
    //    public string Description { get; set; }
    //    public int StartDay { get; set; }
    //    public DateTime AddedAt { get; set; }
    //    public bool BiMonthly { get; set; }
    //    public bool BiMonthlyEven { get; set; }
    //}

}
