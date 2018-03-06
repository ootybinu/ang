using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using WaterAMR.DataAccess.Interfaces;
using WaterAMR.DataModels;
using WaterAMR.DataRepository;
using Microsoft.EntityFrameworkCore;
using WaterAMR.Utility;
using WaterAMR.DataModels.UnitSummary;
using WaterAMR.DataModels.Organization;

namespace WaterAMR.DataAccess
{
    public class CommonRepository  : DataStore, ICommonRepository
    {
        private DbSet<db_KeyValuePair_Text> MasterValues { get; set; }
        private DbSet<db_KeyValuePair> OrganizationValues  { get; set; }
        private DbSet<test> test { get; set; }
        private DbSet<UnitSummary> unit_summary { get; set; }
        private DbSet<Organization> Organization { get; set; }
        private DbSet<DataModels.Billing.BillGroup> BillGrup { get; set; }
        private DbSet<DataModels.Oem.masters> Masters { get; set; }
        private DbSet<DataModels.Oem.Oem> MasterValue { get; set; }
        public CommonRepository(IConfiguration configHelper) : base(configHelper)
        {
        }
        public IEnumerable<db_KeyValuePair_Text> GetMasterValues(string key)
        {
            var qry = from mas in Masters
                      join mv in MasterValue on mas.mastersid equals mv.mastersid
                      where mas.code == key
                      select new db_KeyValuePair_Text { key = mv.code, value = mv.description };
            return qry;

            //string sp = "getmasterdatalist";
            //string criteria = string.Format("'{0}'", key);
            //string query = DbUtility.GetSPName(this.ProviderName, sp, criteria);
            //var result = this.MasterValues.FromSql<db_KeyValuePair_Text>(query);
            //return result;
        }
        public IEnumerable<db_KeyValuePair> GetPlaceList(int parentId, int typeId)
        {
            var result = from org in Organization
                         where org.organizationtypeid == typeId
                         select org;

            if (parentId != -1)
                result = result.Where(or => or.parentid == parentId);
            var ans = from org in result
                         select new db_KeyValuePair { Key = (int)org.organizationid, Value = org.organizationname };
            return ans.ToList();
        }
        public IEnumerable<db_KeyValuePair> GetBillingGroups()
        {
            var result = from bg in BillGrup
                         select new db_KeyValuePair { Key = (int)bg.Id, Value = bg.Code };
            return result;
        }
        public IEnumerable<db_KeyValuePair> GetFromOrganization(int key)
        {
            string sp = "getfromorganization";
            string criteria = string.Format("{0}", key);
            string query = DbUtility.GetSPName(this.ProviderName, sp, criteria);
            var result = this.OrganizationValues.FromSql<db_KeyValuePair>(query);
            return result;
        }
        public void Add()
        {
            //this.test.Add(new test() {  name = "sample", age = 23 });
            //this.test.Add(new test() {  name = "sample2", age = 32 });
            UnitSummary summ = new UnitSummary();
            summ.unitid = "td001";
            this.unit_summary.Add(summ);
            this.SaveChanges();

        }
    }
    public class test {
        [System.ComponentModel.DataAnnotations.Key]
        public int id { get; set; }
        public string name { get; set; }
        public int age { get; set; }
    }
}
