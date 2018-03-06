using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WaterAMR.BusinessModels.UnitReport
{
    public class UnitReport
    {
        public double Id { get; set; }
        public string Consumer { get; set; }
        public string Division { get; set; }
        public string SubDivision { get; set; }
        public string ServiceStation { get; set; }
        public string Location { get; set; }
        public double Consumptioninmcube { get; set; }
        public double DayConsumption { get; set; }
        public DateTime DateRecorded { get; set; }
        public string OEMName { get; set; }
        public string UnitId { get; set; }
        public DateTime InstallOn { get; set; }
        public decimal BatteryVoltage { get; set; }
    }
}
