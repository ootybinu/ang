using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WaterAMR.BusinessModels.Realtime
{
    public class UnitConsumptionHistory
    {
        public string UnitId { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; }
        public decimal ConsumptionInMCube { get; set; }
        public decimal BatteryVoltage { get; set; }
        public string OEMName { get; set; }
        public decimal PulseCount { get; set; }
        public int TamperStatus { get; set; }
    }
}
