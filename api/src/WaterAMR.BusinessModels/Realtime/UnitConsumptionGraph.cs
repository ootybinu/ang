using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WaterAMR.BusinessModels.Realtime
{
    public class UnitConsumptionGraph<T>
    {
        public Graph<T> Cumalative { get; set; }
        public Graph<T> DayConsumption { get; set; }

    }
}
