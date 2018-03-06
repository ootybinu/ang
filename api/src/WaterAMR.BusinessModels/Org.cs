using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WaterAMR.BusinessModels
{
    public class Org
    {
        public int organizationid { get; set; }
        public string code { get; set; }
        public string organizationname { get; set; }
        public int? parentid { get; set; }
    }
}
