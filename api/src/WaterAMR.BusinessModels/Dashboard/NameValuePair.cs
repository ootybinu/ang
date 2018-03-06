using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WaterAMR.BusinessModels.Dashboard
{
    public class NameValuePair<K,V>
    {
        public K name { get; set; }
        public V value { get; set; }
    }
    public class SeriesList<K, V> {
        public string name { get; set; }
        public List<NameValuePair<K,V>> series { get; set; }
    }

    public class ConsumptionData<K,V>
    {
        public List<SeriesList<K,V>> Data { get; set; }
        public List<SeriesList<K, V>> AlternateData { get; set; }
    }

    public class ConsumptionInput {
        public string From { get; set; }
        public string To { get; set; }
        public Int32 UserId { get; set; }
    }
}
