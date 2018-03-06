using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WaterAMR.BusinessModels.Revenue
{
    public class Revenue
    {
        public Int64 Id { get; set; }
        public string MeterType { get; set; }
        public string Division { get; set; }
        public string SubDivision { get; set; }
        public string Unit { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string OEM { get; set; }
        public decimal TotalConsumption { get; set; }
        public decimal revenue { get; set; }
        public string RRNumber { get; set; }
    }

    public class RevenueInput
    {
        public string DivisionId { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
    }
}
