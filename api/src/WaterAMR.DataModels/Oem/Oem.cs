using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WaterAMR.DataModels.Oem
{
    public class OemInput {
        public string Id { get; set; }
    }

    [Table("mastervalue")]
    public class Oem
    {
        [Key]
        public long mastervalueid { get; set; }
        public string code { get; set; }
        public string description { get; set; }
        public long mastersid { get; set; }
        public Int32? parentid { get; set; }
        public string createdby { get; set; }
        public DateTime creationtime { get; set; }
        public string modifiedby { get; set; }
        public DateTime modifiedtime { get; set; }
        public bool isdeleted { get; set; }
        public bool isactive { get; set; }

    }
    [Table("masters")]
    public class masters {
        [Key]
        public long mastersid { get; set; }
        public string code { get; set; }
        public string description { get; set; }
        public bool iseditable { get; set; }
        public bool isvisible { get; set; }
        public string createdby { get; set; }
        public DateTime creationtime { get; set; }
        public string modifiedby { get; set; }
        public DateTime modifiedtime { get; set; }
        public bool isdeleted { get; set; }

    }
    public class oemeffiency {
        [Key]
        public string oemname { get; set; }
        public double effiency { get; set; }
        public string oem { get; set; }
    }
    public class oemefficiencydetail
    {
        [Key]
        public string unitid { get; set; }
        public DateTime installon { get; set; }
        public long daysworked { get; set; }
        public double totaldays { get; set; }
        public string oemname { get; set; }
        public double efficiency { get; set; }
    }

}
