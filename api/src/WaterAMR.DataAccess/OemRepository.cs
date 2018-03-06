using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using WaterAMR.DataAccess.Interfaces;
using WaterAMR.DataModels;
using WaterAMR.DataModels.Oem;
using WaterAMR.DataRepository;
using Microsoft.EntityFrameworkCore;
using WaterAMR.Utility;

namespace WaterAMR.DataAccess
{
    public class OemRepository : DataStore, IOemRepository
    {
        private DbSet<Oem> OEM { get; set; }
        private DbSet<masters> masters { get; set; }
        private DbSet<oemeffiency> Effiency { get; set; }
        private DbSet<oemefficiencydetail> EfficiencyDetail { get; set; }
        public OemRepository(IConfiguration configHelper) : base(configHelper)
        {
        }

        public PagedResponse<Oem> GetAll(PagedData<OemInput> pagedInput)
        {
            bool AllRecords = false;
            var input = pagedInput.Data;
            var result = new PagedResponse<Oem>();

            var start = pagedInput.PageNumber.HasValue ? pagedInput.PageNumber.Value : 1;
            var next = pagedInput.NumberOfRecords.HasValue ? pagedInput.NumberOfRecords.Value : 20;
            AllRecords = (next == -1);
            start = (start - 1) * next;

            var obj = masters.Where(ob => ob.code == "MtrOEMName").FirstOrDefault();
            var OEMKey = obj.mastersid;


            result.TotalRecords = this.OEM.Where(ob=> ob.mastersid == OEMKey).Count();
            if (AllRecords)
                result.Data = this.OEM.Where(ob => ob.mastersid == OEMKey);
            else
                result.Data = this.OEM.Where(ob => ob.mastersid == OEMKey).Skip(start).Take(next);
            return result;
        }

        public string Save(Oem input)
        {
            string flag = "";
            if (input.mastervalueid == 0)
            {
                var obj = masters.Where(ob => ob.code == "MtrOEMName").FirstOrDefault();
                var OEMKey = obj.mastersid;
                input.mastersid = OEMKey;
                input.createdby = input.modifiedby;
                input.creationtime = DateTime.Now;
                input.modifiedtime = DateTime.Now;
                this.OEM.Add(input);
                //this.SaveChanges();
            }
            else
            {
                input.modifiedtime = DateTime.Now;
                var original = this.OEM.Where(ob => ob.mastervalueid == input.mastervalueid).FirstOrDefault();
                if (original != null)
                {
                    original.description = input.description;
                    original.modifiedby = input.modifiedby;
                    original.modifiedtime = DateTime.Now;
                    this.OEM.Update(original);
                    //this.SaveChanges();
                }
            }
            try
            {
                this.SaveChanges();
            }
            catch (Exception ex)
            {
                flag = ex.Message;
            }
            return flag;
        }

        public IEnumerable<oemeffiency> GetOemEffiency()
        {
            string sp = "getoemeffiency";
            string query = DbUtility.GetSPName(this.ProviderName, sp, "");
            var result = this.Effiency.FromSql<oemeffiency>(query);
            return result;
        }

        public IEnumerable<oemefficiencydetail> GetOemEfficiencyDetail(string oemCode)
        {
            string sp = "getoemefficiencydetail";
            string criteria = string.Format("'{0}'", oemCode);
            string query = DbUtility.GetSPName(this.ProviderName, sp, criteria);
            var result = this.EfficiencyDetail.FromSql<oemefficiencydetail>(query);
            return result;
        }
    }
}
