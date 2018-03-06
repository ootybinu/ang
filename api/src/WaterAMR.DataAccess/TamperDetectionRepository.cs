using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using WaterAMR.DataAccess.Interfaces;
using WaterAMR.DataModels;
using WaterAMR.DataModels.TamperDetection;
using WaterAMR.DataRepository;
using Microsoft.EntityFrameworkCore;
using WaterAMR.DataModels.UnitSummary;

namespace WaterAMR.DataAccess
{
    public class TamperDetectionRepository : DataStore, ITamperDetectionRepository
    {
        private DbSet<UnitSummary> unitSummary { get; set; }
        private DbSet<TamperData> tamperData { get; set; }
        public TamperDetectionRepository(IConfiguration configHelper) : base(configHelper)
        {
        }

        public PagedResponse<TamperData> GetData(PagedData<TamperCriteria> pagedInput)
        {
            bool AllRecords = false;
            var input = pagedInput.Data;
            var result = new PagedResponse<TamperData>();

            var start = pagedInput.PageNumber.HasValue ? pagedInput.PageNumber.Value : 1;
            var next = pagedInput.NumberOfRecords.HasValue ? pagedInput.NumberOfRecords.Value : 20;
            AllRecords = (next == -1);
            start = (start - 1) * next;

            string qry = "select md.id,md.date, us.unitid, fnGetOrganizationName(us.locationid) as location, fnGetOrganizationName(us.servicestnid) as servicestation, " +
                        "fnGetOrganizationName(us.subdivisionid) as subdivision, fnGetOrganizationName(divisionid) as division, md.tamperstatus " +
                        "from unit_summary us inner join message_data md " +
                        "on us.id = md.unitid where md.tamperstatus =1 ";
            if (input.Criteria != "")
                qry += " and " + input.Criteria;
            var res = this.tamperData.FromSql<TamperData>(qry);

            //result.TotalRecords = this.tamperData.Count();
            result.TotalRecords = res.Any()? res.Count():0;
            if (AllRecords)
                result.Data = res;
            else
                result.Data = res.Skip(start).Take(next);
            return result;

        }

        public IEnumerable<KeyValuePair<string, string>> GetUnitList(string location)
        {
            var result = unitSummary.Where(ob => ob.locationid == Convert.ToInt32(location)).Select(n => new KeyValuePair<string, string>(n.unitid, n.unitid));
            return result;
        }
    }
}
