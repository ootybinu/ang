using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WaterAMR.DataModels
{
    public class Scaler
    {
        [Key]
        public decimal getsumofmeterconsumption { get; set; }
    }
}
