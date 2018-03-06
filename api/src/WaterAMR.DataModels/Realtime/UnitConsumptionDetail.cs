using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WaterAMR.DataModels.Realtime
{
    [Table("unitsconsumptiondetails")]
    public class UnitConsumptionDetail
    {
        public double id { get; set; }
        public DateTime daterecorded { get; set; }
        public double unitid { get; set; }
        public double consumptioninmcube { get; set; }
        public double dayconsumption { get; set; }
        public DateTime addedat { get; set; }
        public double messagedataid { get; set; }
    }
}
