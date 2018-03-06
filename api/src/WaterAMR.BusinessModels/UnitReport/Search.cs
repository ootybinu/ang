using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WaterAMR.BusinessModels.UnitReport
{
    public class Search
    {
        public IEnumerable<KeyValuePair<string,string>> MeterTypes { get; set; }
        public IEnumerable<KeyValuePair<String,string>> OEMs { get; set; }
        public IEnumerable<KeyValuePair<Int32,string>> Divisions { get; set; }
    }
}
