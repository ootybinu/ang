using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WaterAMR.Utility
{
    public class Token
    {
        public string Id { get; set; }
        public int UserId { get; set; }
        public TimeSpan ExpiresAt { get; set; }
    }
}
