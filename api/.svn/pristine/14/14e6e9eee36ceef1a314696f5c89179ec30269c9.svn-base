using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using WaterAMR.DataAccess.Interfaces;
using WaterAMR.DataModels.Tariff;
using WaterAMR.DataRepository;
using Microsoft.EntityFrameworkCore;
using WaterAMR.DataModels;

namespace WaterAMR.DataAccess
{
    public class TariffRepository : DataStore, ITariffRepository
    {
        DbSet<DataModels.Billing.TariffMaster> Tariff { get; set; }
        DbSet<DataModels.Billing.InitTariff> InitTariff { get; set; }
        DbSet<DataModels.Oem.masters> Masters { get; set; }
        DbSet<DataModels.Oem.Oem> MasterValue { get; set; }
        public TariffRepository(IConfiguration configHelper) : base(configHelper)
        {
        }

        public string Generate(TariffInput input)
        {
            var result = "Success";
            var exist = (from ta in Tariff
                         where ta.Year == input.Year
                         && ta.DivisionId == input.DivisionId
                         select ta).Any();
            if (exist)
                return "Data already exist for this criteria";
            var rec = from ta in InitTariff
                      select new DataModels.Billing.TariffMaster()
                      {
                          Borewell = ta.Borewell,
                          CategoryId = ta.CategoryId,
                          DivisionId = input.DivisionId,
                          MeterCost = ta.MeterCost,
                          Sanitary = ta.Sanitary,
                          SanitaryType = ta.SanitaryType,
                          SlabMax = ta.SlabMax,
                          SlabMin = ta.SlabMin,
                          Tariff = ta.Tariff,
                          Year = input.Year
                      };
            Tariff.AddRange(rec.ToList());
            SaveChanges();
            return result;
        }

        public PagedResponse<DataModels.Tariff.TariffMasterFull> GetTariffConfig(PagedData<TariffInput> pagedInput)
        {
            var result = new PagedResponse<DataModels.Tariff.TariffMasterFull>();
            bool AllRecords = false;
            var input = pagedInput.Data;
            var start = pagedInput.PageNumber.HasValue ? pagedInput.PageNumber.Value : 1;
            var next = pagedInput.NumberOfRecords.HasValue ? pagedInput.NumberOfRecords.Value : 20;
            AllRecords = (next == -1);
            start = (start - 1) * next;

            var qry = from tar in Tariff
                      where tar.Year == input.Year
                      && tar.DivisionId == input.DivisionId
                      join mv in MasterValue on tar.CategoryId equals mv.code
                      join mas in Masters on mv.mastersid equals mas.mastersid
                      where mas.code == "MeterBillingType"
                      orderby tar.CategoryId, tar.SlabMin
                      select new TariffMasterFull()
                      {
                          Borewell = tar.Borewell,
                          CategoryId = tar.CategoryId,
                          Category = mv.description,
                          DivisionId = tar.DivisionId,
                          Id = tar.Id,
                          MeterCost = tar.MeterCost,
                          Sanitary = tar.Sanitary,
                          SanitaryType = tar.SanitaryType,
                          SlabMax = tar.SlabMax,
                          SlabMin = tar.SlabMin,
                          Tariff = tar.Tariff,
                          Year = tar.Year
                      };
            result.TotalRecords = qry.Count();

            if (AllRecords)
                result.Data = qry;
            else
                result.Data = qry.Skip(start).Take(next);
            return result;
        }
        public string Update(DataModels.Billing.TariffMaster tariff)
        {
            var result = "Success";
            if (tariff.Id == 0)
            {
                var r = Tariff.Add(tariff);
                var s = this.SaveChanges();
                return result;
            }
            var original = (from ta in Tariff where ta.Id == tariff.Id select ta).FirstOrDefault();
            if (original != null)
            {
                original.MeterCost = tariff.MeterCost;
                original.SlabMax = tariff.SlabMax;
                original.SlabMin = tariff.SlabMin;
                original.Sanitary = tariff.Sanitary;
                original.SanitaryType = tariff.SanitaryType;
                original.Tariff = tariff.Tariff;
                original.Borewell = tariff.Borewell;
                Tariff.Update(original);
                this.SaveChanges();
            }
            // Tariff.Update(tariff).State = EntityState.Modified;
            //var res=  Tariff.Update(tariff);

            // this.SaveChanges();
            return result;
        }
        public string Delete(DataModels.Billing.TariffMaster tariff)
        {
            var result = "Success";
            var tar = (from ta in Tariff
                       where ta.Id == tariff.Id
                       select ta).FirstOrDefault();
            if (tar != null)
            {
                Tariff.Remove(tar);
                this.SaveChanges();
            }
            return result;
        }
    }
}
