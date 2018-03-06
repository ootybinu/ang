using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WaterAMR.DataModels.Revenue
{
    public class Revenue
    {
        [Key]
        public Int64 id { get; set; }
        public string meterbillingtype { get; set; }
        public string division { get; set; }
        public string subdivision { get; set; }
        public string unit { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string oem { get; set; }
        public decimal totalconsumption { get; set; }
        public decimal revenue { get; set; }
        public string rrnumber { get; set; }
    }

    public class RevenueInput
    {
        public string DivisionId { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
    }
}
