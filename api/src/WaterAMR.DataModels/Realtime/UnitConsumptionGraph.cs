using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WaterAMR.DataModels.Realtime
{
    public class UnitConsumptionGraph<T>
    {
        public Graph<T> Cumalative { get; set; }
        public Graph<T> DayConsumption { get; set; }

    }
}
