using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using WaterAMR.DataAccess.Interfaces;
using WaterAMR.DataModels;
using WaterAMR.DataModels.Revenue;
using WaterAMR.DataRepository;
using WaterAMR.Utility;
using Microsoft.EntityFrameworkCore;

namespace WaterAMR.DataAccess
{
    public class RevenueRepository :DataStore, IRevenueRepository
    {
        private DbSet<Revenue> RevenueRows { get; set; }
        private DbSet<Scaler> TotalRevenue { get; set; }
        public RevenueRepository(IConfiguration configHelper) : base(configHelper)
        {
        }

        public PagedResponse<Revenue> GetRevenueList(PagedData<RevenueInput> pagedInput)
        {
            bool AllRecords = false;
            var input = pagedInput.Data;
            var result = new PagedResponse<Revenue>();
            var id = string.IsNullOrEmpty(input.DivisionId) ? 0 : Convert.ToInt32(input.DivisionId);
            string criteria = string.Format("{0},'{1}','{2}'", id, input.FromDate, input.ToDate);
            string sp = "getmeterconsumption";
            var start = pagedInput.PageNumber.HasValue ? pagedInput.PageNumber.Value : 1;
            var next = pagedInput.NumberOfRecords.HasValue ? pagedInput.NumberOfRecords.Value : 20;
            AllRecords = (next == -1);

            start = (start - 1) * next;
            string query = DbUtility.GetSPName(this.ProviderName, sp, criteria);
            
            result.TotalRecords = this.RevenueRows.FromSql<Revenue>(query).Count();

            if (AllRecords)
                result.Data = this.RevenueRows.FromSql<Revenue>(query);
            else
                result.Data = this.RevenueRows.FromSql<Revenue>(query).Skip(start).Take(next);
            if (result.Data.Count() > 0)
            {
                sp = "getsumofmeterconsumption";
                query = DbUtility.GetSPName(this.ProviderName, sp, criteria);

                var TotalPrice = this.TotalRevenue.FromSql<Scaler>(query);
                result.MetaData = TotalPrice.ToList()[0].getsumofmeterconsumption;
            }
            else
            { result.MetaData = 0; }
            return result;
        }
    }
}
