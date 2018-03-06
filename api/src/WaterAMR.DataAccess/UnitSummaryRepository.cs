using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using WaterAMR.DataAccess.Interfaces;
using WaterAMR.DataModels.UnitSummary;
using WaterAMR.DataRepository;
using WaterAMR.Utility;
using Microsoft.EntityFrameworkCore;
using WaterAMR.DataModels;
using WaterAMR.DataModels.Billing;

namespace WaterAMR.DataAccess
{
    public class UnitSummaryRepository : DataStore, IUnitSummaryRepository
    {
        private DbSet<db_KeyValuePair_Text> kp { get; set; }
        private DbSet<db_KeyValuePair> kv { get; set; }
        private DbSet<UnitSummaryRow> Rows { get; set; }
        private DbSet<UnitSummary> unit_summary { get; set; }
        private DbSet<db_KeyValuePair> SubList { get; set; }
        private DbSet<BillGroup> BillGroup { get; set; }
        private DbSet<DataModels.Organization.Organization> Organization { get; set; }
        private DbSet<DataModels.User.employee> Employee { get; set; }
        private DbSet<DataModels.User.employeeloginmapping> EmployeeLoginMapping { get; set; }
        private DbSet<DataModels.User.loginmaster> LoginMaster { get; set; }
        private IUserInjection Context;

        public UnitSummaryRepository(IConfiguration configHelper,  IUserInjection userinjection) : base(configHelper)
        {
            Context = userinjection;
        }

        public UnitSummaySelectionLists GetInitialLists()
        {
            var result = new UnitSummaySelectionLists();
            string sp = "getmasterdatalist";
            string criteria = string.Format("'{0}'", "MeterType");
            string query = DbUtility.GetSPName(this.ProviderName, sp, criteria);
            result.MeterTypes= this.kp.FromSql<db_KeyValuePair_Text>(query);

            criteria = string.Format("'{0}'", "MtrOEMName");
            query = DbUtility.GetSPName(this.ProviderName, sp, criteria);
            result.OEMNames = this.kp.FromSql<db_KeyValuePair_Text>(query);

            criteria = string.Format("'{0}'", "FlowType");
            query = DbUtility.GetSPName(this.ProviderName, sp, criteria);
            result.FlowTypes = this.kp.FromSql<db_KeyValuePair_Text>(query);

            criteria = string.Format("'{0}'", "MeterBillingType");
            query = DbUtility.GetSPName(this.ProviderName, sp, criteria);
            result.MeterBillingTypes = this.kp.FromSql<db_KeyValuePair_Text>(query);

            criteria = string.Format("'{0}'", "SimSvcPro");
            query = DbUtility.GetSPName(this.ProviderName, sp, criteria);
            result.MobileServiceProviders = this.kp.FromSql<db_KeyValuePair_Text>(query);

            criteria = string.Format("'{0}'", "CommMode");
            query = DbUtility.GetSPName(this.ProviderName, sp, criteria);
            result.CommModes = this.kp.FromSql<db_KeyValuePair_Text>(query);

            criteria = string.Format("'{0}'", "WeekName");
            query = DbUtility.GetSPName(this.ProviderName, sp, criteria);
            result.WeekNames = this.kp.FromSql<db_KeyValuePair_Text>(query);

            criteria = string.Format("'{0}'", "DivisionDesignation");
            query = DbUtility.GetSPName(this.ProviderName, sp, criteria);
            result.DivisionHeads = this.kp.FromSql<db_KeyValuePair_Text>(query);

            criteria = string.Format("'{0}'", "SubDivisionDesignation");
            query = DbUtility.GetSPName(this.ProviderName, sp, criteria);
            result.SubDivisionHeads = this.kp.FromSql<db_KeyValuePair_Text>(query);

            //sp = "getconsumernames";
            //query = DbUtility.GetSPName(this.ProviderName, sp, "");
            //result.ConsumerNames = this.kp.FromSql<db_KeyValuePair_Text>(query);
            var userid = Context.GetUser();
            long? division=0;
            var emp = (from em in Employee
                       where em.employeeid == userid
                       select em).FirstOrDefault();
            if (emp != null)
                division = emp.divisionid;
            var qry = from em in Employee
                      join elm in EmployeeLoginMapping on em.employeeid equals elm.employeeid
                      join lm in LoginMaster on elm.loginname equals lm.loginname
                      where lm.roles == 2 && em.divisionid == division
                      select new db_KeyValuePair_Text { key = em.employeeid.ToString(),
                          value = em.firstname + (em.midname==null?"":em.midname )
                      + (em.lastname==null ?"" :em.lastname) };
            result.ConsumerNames = qry.ToList();


            sp = "getdivisions";
            query = DbUtility.GetSPName(this.ProviderName, sp, "");
            result.Divisions = this.kv.FromSql<db_KeyValuePair>(query);
            var bgs = (from bg in BillGroup
                       select new KeyValuePair<int, string>((int)bg.Id, bg.Description)).ToList();
            result.BillGroups = bgs;
            return result;

        }

        public PagedResponse<UnitSummaryRow> GetAll(PagedData<SearchParam> pagedInput)
        {
            bool AllRecords = false;
            var input = pagedInput.Data;
            var result = new PagedResponse<UnitSummaryRow>();
            //string qry = "select id,unitid,installon,pipesize,fngetorganizationname(divisionid) as division, "+
            //            "fngetorganizationname(subdivisionid) as subdivision, fngetorganizationname(servicestnid) as servicestation," +
            //            "fngetorganizationname(locationid) as location, mobilenumberofunit, metercalibfactor, initialmeterreading, ltrperpulse, tariffperltr" +
            //             " from unit_summary order by 1 desc";
            var start = pagedInput.PageNumber.HasValue ? pagedInput.PageNumber.Value : 1;
            var next = pagedInput.NumberOfRecords.HasValue ? pagedInput.NumberOfRecords.Value : 20;
            AllRecords = (next == -1);

            start = (start - 1) * next;

            //if (input != null)
            //{
            //    if (!string.IsNullOrEmpty(input.MobileNumber))
            //    {
            //        qry += " where mobilenumberofunit = '" + input.MobileNumber + "'";
            //    }
            //}
            //var userid = from tok in Tokens where tok.Id
            var userid = Context.GetUser();
            var emp = (from empl in Employee where empl.employeeid == userid select empl).FirstOrDefault();

            var units = from us in unit_summary
                        join orgD in Organization on us.divisionid equals orgD.organizationid 
                        join orgSD in Organization on us.subdivisionid equals orgSD.organizationid 
                        join orgSt in Organization on us.servicestnid equals orgSt.organizationid
                        join OrgL in Organization on us.locationid equals OrgL.organizationid
                        select new UnitSummaryRow { id = us.id, unitid = us.unitid, installon = us.installon, pipesize = us.pipesize,
                            division = orgD.organizationname, subdivision = orgSD.organizationname, servicestation = orgSt.organizationname, 
                            location = OrgL.organizationname, mobilenumberofunit = us.mobilenumberofunit, 
                             metercalibfactor = us.metercalibfactor, initialmeterreading = us.initialmeterreading, 
                              ltrperpulse = us.ltrperpulse, tariffperltr = us.tariffperltr
                        };
            if (input != null && !string.IsNullOrEmpty(input.MobileNumber))
                units = units.Where(t => t.mobilenumberofunit == input.MobileNumber);
            if (emp != null && emp.divisionid != null)
            {
                var _units = from un in units
                             join orig in unit_summary
                             on un.id equals orig.id
                             where orig.divisionid == emp.divisionid
                             select un;
                units = _units;
            }

            result.TotalRecords = units.Count();

            result.Data = AllRecords ? units : units.Skip(start).Take(next);


            //result.TotalRecords = this.Rows.FromSql<UnitSummaryRow>(qry).Count();
            //if (AllRecords)
            //    result.Data = this.Rows.FromSql<UnitSummaryRow>(qry);
            //else
            //    result.Data = this.Rows.FromSql<UnitSummaryRow>(qry).Skip(start).Take(next);
            return result;
        }

        public UnitSummaryResult GetDetail(string id)
        {
            var result = new UnitSummaryResult();
            //string qry = "select * from unit_summary where id = " + id;
            // result.Data = this.unit_summary.FromSql<UnitSummary>(qry).FirstOrDefault();
            result.Data = (from us in unit_summary
                           where us.id == Convert.ToInt64(id)
                           select us).FirstOrDefault();
            result.SubDivisions = (from org in Organization
                                   where org.parentid == result.Data.divisionid &&
                                   org.organizationtypeid == 2
                                   select new db_KeyValuePair { Key = (int)org.organizationid, Value = org.organizationname }).ToList();
            result.ServiceStations = (from org in Organization
                                   where org.parentid == result.Data.subdivisionid &&
                                   org.organizationtypeid == 4
                                   select new db_KeyValuePair { Key = (int)org.organizationid, Value = org.organizationname }).ToList();

            result.Locations = (from org in Organization
                                   where org.parentid == result.Data.servicestnid &&
                                   org.organizationtypeid == 3
                                   select new db_KeyValuePair { Key = (int)org.organizationid, Value = org.organizationname }).ToList();

            //result.SubDivisions = this.GetSubList(result.Data.divisionid, 2);
            //result.ServiceStations = this.GetSubList(result.Data.subdivisionid, 4);
            //result.Locations = this.GetSubList(result.Data.servicestnid, 3);
            return result;   
        }


        public bool UpdateUnit(UnitSummary unitSummary)
        {
            bool flag = true;
            if (unitSummary.id == 0)
                this.unit_summary.Add(unitSummary);
            else 
                this.unit_summary.Update(unitSummary);
            
            this.SaveChanges();
            return flag;
            
        }
        private IEnumerable<db_KeyValuePair> GetSubList(Int32 parentId, Int32 typeId)
        {
            if (typeId == -1)
            {
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

    }
}
