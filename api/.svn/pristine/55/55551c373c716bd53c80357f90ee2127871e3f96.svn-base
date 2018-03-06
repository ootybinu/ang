using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterAMR.DataAccess.Interfaces;
using WaterAMR.DataModels.GPRSdata;
using WaterAMR.DataRepository;
using WaterAMR.Utility;
using Microsoft.Extensions.Configuration;

namespace WaterAMR.DataAccess
{
    public class GPRSdataRepository : DataStore,   IGPRSdataRepository
    {
        public GPRSdataRepository(IConfiguration configHelper) : base(configHelper)
        {
        }

        private DbSet<GprsData> GPRSdataRows { get; set; }
        private DbSet<GprsDetail> GprsDetailRows { get; set; }
        private DbSet<GprsDetail> GprsHistoryRows { get; set; }

        public IEnumerable<GprsData> GetGprsData(string onDate)
        {
            string sp = "getgprsdata";
            string criteria = string.Format("'{0}'",onDate);
            string query = DbUtility.GetSPName(this.ProviderName, sp, criteria);
            var result = this.GPRSdataRows.FromSql<GprsData>(query);
            return result;
        }

        public IEnumerable<GprsDetail> GetGprsHistory(string id)
        {
            string sp = "getgprshistory";
            string criteria = string.Format("{0}", id);
            string query = DbUtility.GetSPName(this.ProviderName, sp, criteria);
            var result = this.GprsHistoryRows.FromSql<GprsDetail>(query);
            return result;
        }

        public IEnumerable<GprsDetail> GetGprsDetail(string id, string ondate)
        {
            string sp = "getgprshistory2";
            string criteria = string.Format("{0},'{1}'", id, ondate);
            string query = DbUtility.GetSPName(this.ProviderName, sp, criteria);
            var result = this.GprsDetailRows.FromSql<GprsDetail>(query);
            return result;
        }
    }
}
