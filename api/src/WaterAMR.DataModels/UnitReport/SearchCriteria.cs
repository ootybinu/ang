using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WaterAMR.DataModels.UnitReport
{
    public class SearchCriteria
    {
        public string MeterType { get; set; }
        public string OEMId { get; set; }
        public string Division { get; set; }
        public string SubDivision { get; set; }
        public string Service { get; set; }
        public string Location { get; set; }
        public string Consumer { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
    }
}
