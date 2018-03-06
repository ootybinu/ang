using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WaterAMR.DataModels
{
    public class db_KeyValuePair
    {
        [Key]
        public int Key { get; set; }
        public string Value { get; set; }
    }
}
