using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using WaterAMR.DataAccess;
using WaterAMR.DataAccess.Interfaces;
using WaterAMR.DataModels.UnitReport;
using WaterAMR.DataRepository;
using WaterAMR.Utility;
using Microsoft.EntityFrameworkCore;
using WaterAMR.DataModels;

namespace WaterAMR.DataAccess
{
    public class UnitReportRepository : DataStore, IUnitReportRepository
    {
        private DbSet<db_KeyValuePair_Text> MeterTypeList { get; set; }
        private DbSet<db_KeyValuePair> DivisionList { get; set; }
        private DbSet<db_KeyValuePair_Text> OEMList { get; set; }
        private DbSet<db_KeyValuePair> SubList{ get; set; }
        private DbSet<UnitReport> UnitReportRows { get; set; }

        public UnitReportRepository(IConfiguration configHelper) : base(configHelper)
        {
        }

        public Search GetInitialSearchLists(GenericRequest request )
        {
            var result = new Search();
            string sp = "getmasterdatalist";
            string criteria = string.Format("'{0}'", "MeterType");
            string query = DbUtility.GetSPName(this.ProviderName, sp, criteria);
            result.MeterTypes = this.MeterTypeList.FromSql<db_KeyValuePair_Text>(query);
            sp = "getdivisionbasedonroles";
            criteria = string.Format("{0},{1},'{2}','{3}','{4}'", request.UserId, request.RoleId, request.OEM, request.Organization, request.Designation);
            query = DbUtility.GetSPName(this.ProviderName, sp, criteria);
            result.Divisions = this.DivisionList.FromSql<db_KeyValuePair>(query);
            sp = "getmastervaluelist";
            criteria = string.Format("{0}",5);// 5 for OEM 
            query = DbUtility.GetSPName(this.ProviderName, sp, criteria);
            result.OEMs = this.OEMList.FromSql<db_KeyValuePair_Text>(query);
            return result;
        }

        public IEnumerable<db_KeyValuePair> GetSubList(Int32 parentId, Int32 typeId)
        {
            if (typeId == -1) {
                string sp = "getsublistemp";
                string criteria = string.Format("{0}", parentId);
                string query = DbUtility.GetSPName(this.ProviderName, sp, criteria);
                var result = this.SubList.FromSql<db_KeyValuePair>(query);
                return result;
            }
            else
            {
                string sp = "getsublist";
                string criteria = string.Format("{0},{1}", parentId, typeId);
                string query = DbUtility.GetSPName(this.ProviderName, sp, criteria);
                var result = this.SubList.FromSql<db_KeyValuePair>(query);
                return result;
            }
        }

        public PagedResponse<UnitReport> GetUnitReport(PagedData<SearchCriteria> pagedInput)
        {
            bool AllRecords = false;
            var input = pagedInput.Data;
            var result = new PagedResponse<UnitReport>();
            string sp = "getunitreport";
            var start = pagedInput.PageNumber.HasValue ? pagedInput.PageNumber.Value : 1;
            var next = pagedInput.NumberOfRecords.HasValue ? pagedInput.NumberOfRecords.Value : 20;
            AllRecords = (next == -1);

            start = (start - 1) * next;
            var sc = pagedInput.Data;
            string criteria = string.Format("'{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}'", sc.MeterType, sc.OEMId, 
                sc.Division, sc.SubDivision, sc.Service, sc.Location, sc.Consumer, sc.FromDate, sc.ToDate);
            string query = DbUtility.GetSPName(this.ProviderName, sp, criteria);
            result.TotalRecords = this.UnitReportRows.FromSql<UnitReport>(query).Count();
            if (AllRecords)
                result.Data = this.UnitReportRows.FromSql<UnitReport>(query);
            else
                result.Data = this.UnitReportRows.FromSql<UnitReport>(query).Skip(start).Take(next);
            return result;
        }
    }
}
