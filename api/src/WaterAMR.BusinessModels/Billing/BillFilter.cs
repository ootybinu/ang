using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WaterAMR.BusinessModels.Billing
{
    public class BillFilter
    {
        public string MonthYear { get; set; }
        public string DivisionId { get; set; }
        public string SubDivisionId { get; set; }
        public string ServiceId { get; set; }
        public string LocationId { get; set; }

    }
}
