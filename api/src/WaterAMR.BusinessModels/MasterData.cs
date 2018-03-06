using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WaterAMR.BusinessModels
{
    public class MasterData
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public Int32 MasterValueId { get; set; }
        public Int32 MastersId { get; set; }
    }
}
