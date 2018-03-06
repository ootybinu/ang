using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterAMR.DataAccess.Interfaces;
using WaterAMR.DataModels;
using WaterAMR.DataRepository;
using WaterAMR.Utility;
using WaterAMR.DataModels.Organization;
using System.ComponentModel.DataAnnotations;

namespace WaterAMR.DataAccess
{
    public class OrganizationRepository :DataStore,   IOrganizationRepository
    {
        //private DbSet<Org> Orgs { get; set; }
        private DbSet<Organization> Organization { get; set; }
        private DbSet<temp> Scaler { get; set; }
        public OrganizationRepository(IConfiguration config ):base(config)
        {

        }


        public IEnumerable<Org> GetOrganizations()
        {
            return null;
            //return this.Orgs;
            //var r = DbSet<Organization>();
            //var result1 = new List<DataModels.Organization>();
            //result1.Add(new DataModels.Organization() { organizationid = 1, code = "1", organizationname = "simple" });

            //return result;
        }

        public IEnumerable<OrgShort> GetOrgMembers(OrgInput input)
        {
            var result = this.Organization.Where(ob => ob.parentid == input.parentid).Select(ob =>
            
                new OrgShort{
                    code = ob.code,
                    organizationid = ob.organizationid,
                    organizationname = ob.organizationname,
                    organizationtypeid = ob.organizationtypeid,
                    parentid = ob.parentid, 
                    createdby = ob.createdby
                }
            );
            return result.ToList();
        }

        public  string UpdateOrg(OrgShort org)
        {
            var result = "Success";
            var qry = (from orgData in Organization
                       where orgData.parentid == org.parentid &&
                       orgData.organizationname == org.organizationname &&
                       orgData.organizationtypeid == org.organizationtypeid
                       select orgData);
            if (qry.Any())
                return "Duplicate values, Data with same name exists!";
            var item = this.Organization.Where(ob => ob.organizationid == org.organizationid).FirstOrDefault();
            if (item != null)
            {
                item.organizationname = org.organizationname;
                item.modifiedby = org.createdby;
                item.modifiedtime = DateTime.Now;
                this.Organization.Update(item);
                this.SaveChanges();
            }
            return result;
        }

        public string AddOrg(OrgShort org)
        {
            var result = "Success";
            var qry = (from orgData in Organization
                       where orgData.parentid == org.parentid &&
                       orgData.organizationname == org.organizationname &&
                       orgData.organizationtypeid == org.organizationtypeid
                       select orgData);
            if (qry.Any())
                return "Duplicate values, Data with same name exists!";


            var item = new Organization();
            item.organizationname = org.organizationname;
            item.organizationtypeid = org.organizationtypeid;
            item.parentid = org.parentid;
            item.code = org.code;
            item.createdby = org.createdby;
            item.creationtime = DateTime.Now;
            item.isdeleted = false;
            this.Organization.Add(item);
            this.SaveChanges();
            return result;
        }

        public string DeleteOrg(OrgShort org)
        {
            string result = "Success";
            string sp = "", query = "", criteria="";
            sp = "delorganization";
            criteria = string.Format("{0},{1}", org.organizationid, org.organizationtypeid);
            query = DbUtility.GetSPName(this.ProviderName, sp, criteria);
            var recs = this.Scaler.FromSql(query);
            result = recs.ToList()[0].delorganization;
            return  result ==""?"Success":result ;
        }
        private class temp
        {
            [Key]
            public string delorganization { get; set; }
        }
    }
}
