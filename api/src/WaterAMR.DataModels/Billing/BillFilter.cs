using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WaterAMR.DataModels.Billing
{
    public class BillFilter
    {
        public string MonthYear { get; set; }
        public string DivisionId { get; set; }
        public string SubDivisionId { get; set; }
        public string ServiceId { get; set; }
        public string LocationId { get; set; }
    }
    //public class BGInput {
    //    public long DivisionId { get; set; }
    //}
}
