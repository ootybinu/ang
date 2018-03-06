using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WaterAMR.DataModels.Billing
{
    [Table("tariff_master")]
    public class TariffMaster
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string CategoryId { get; set; }
        public double SlabMin { get; set; }
        public double SlabMax { get; set; }
        public double Tariff { get; set; }
        public double Sanitary { get; set; }
        public string SanitaryType { get; set; }
        public double Borewell { get; set; }
        public double MeterCost { get; set; }
        public int Year { get; set; }
        public int DivisionId { get; set; }
                   
    }

    [Table("inittariff")]
    public class InitTariff
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string CategoryId { get; set; }
        public double SlabMin { get; set; }
        public double SlabMax { get; set; }
        public double Tariff { get; set; }
        public double Sanitary { get; set; }
        public string SanitaryType { get; set; }
        public double Borewell { get; set; }
        public double MeterCost { get; set; }
        public int Year { get; set; }
        public int DivisionId { get; set; }
    }


}
