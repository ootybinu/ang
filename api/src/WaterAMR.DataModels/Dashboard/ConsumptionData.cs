using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WaterAMR.DataModels.Dashboard
{
    public class ConsumptionData
    {
        public List<KeyValuePair<string, List<KeyValuePair<string, decimal>>>> Data { get; set; }
        public List<KeyValuePair<string, List<KeyValuePair<string, decimal>>>> AlternateData { get; set; }
    }
    public class ConsumptionInput
    {
        public string From { get; set; }
        public string To { get; set; }
        public Int32 UserId { get; set; }
    }
    public class ConsumptionResult
    {
        public DateTime period { get; set; }
        public int month { get; set; }
        public int year { get; set; }
        public string unitid { get; set; }
        public decimal consumption { get; set; }
    }
}
