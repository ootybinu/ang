using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using WaterAMR.DataAccess.Interfaces;
using WaterAMR.DataModels;
using WaterAMR.DataModels.Realtime;
using WaterAMR.DataRepository;
using WaterAMR.Utility;

namespace WaterAMR.DataAccess
{
    public class UnitConsumptionRepository : DataStore, IUnitConsumptionRepository
    {
        private DbSet<UnitConsumption> UnitConsumptionRows { get; set; }
        private DbSet<db_KeyValuePair> OrganizationRows {get;set;}
        private DbSet<db_KeyValuePair_Text> RRNumberRows { get; set; }
        private DbSet<MasterData> OEM { get; set; }
        private DbSet<UnitConsumptionHistory> HistoryUnitRows { get; set; }

        private DbSet<DataModels.UnitSummary.UnitsConsumptionDetails> UnitsConsumptionDetails { get; set; }
        private DbSet<DataModels.UnitSummary.UnitSummary> UnitSummary { get; set; }
        private DbSet<DataModels.Organization.Organization> Organization { get; set; }
        private DbSet<DataModels.UnitSummary.message_data> Message_Data { get; set; }
        private DbSet<DataModels.UnitSummary.MessageRejected> MessageRejected { get; set; }
        private DbSet<DataModels.User.employee> Employee { get; set; }
        private DbSet<DataModels.Oem.masters> Masters { get; set; }
        private DbSet<DataModels.Oem.Oem> MasterValue { get; set; }
        public UnitConsumptionRepository(IConfiguration config):base(config)
        {

        }
        public PagedResponse<UnitConsumption> GetTodayData(PagedData<GenericRequest> pagedInput, SearchParam searchParam)
        {
            bool AllRecords = false;
            var input = pagedInput.Data;
            var result = new PagedResponse<UnitConsumption>();

            var start = pagedInput.PageNumber.HasValue ? pagedInput.PageNumber.Value : 1;
            var next = pagedInput.NumberOfRecords.HasValue ? pagedInput.NumberOfRecords.Value : 20;
            AllRecords = (next == -1);

            start = (start - 1 )* next;
            var searchDate = (searchParam != null && searchParam.Date != null) ? Convert.ToDateTime(searchParam.Date) : DateTime.Today;
            var user = (from em in Employee
                        where em.employeeid == input.UserId
                        select em).FirstOrDefault();

            var units = from us in UnitSummary
                        join ucd in UnitsConsumptionDetails
                        on us.id equals ucd.unitid
                        where ucd.daterecorded == searchDate
                        group new { US = us, UCD = ucd } by us.unitid
                        into g
                        select g.OrderByDescending(m => m.UCD.consumptioninmcube).FirstOrDefault();
            //                        select new { US = us, UCD = ucd };
            var MeterNotReceived = from us in UnitSummary
                                   join uni in units 
                                   on us.id equals uni.US.id into rec 
                                   from r in rec.DefaultIfEmpty()
                                   where r== null
                                   select us;

            if (user.heads == "D")
            { units = units.Where(ob => ob.US.divisionid == user.divisionid);
                MeterNotReceived = MeterNotReceived.Where(ob => ob.divisionid == user.divisionid);
            }
            if (user.heads == "SD")
            { units = units.Where(ob => ob.US.subdivisionid == user.subdivisionid);
                MeterNotReceived = MeterNotReceived.Where(ob => ob.subdivisionid == user.subdivisionid);
            }
            if (searchParam != null)
            {
                if (!string.IsNullOrEmpty(searchParam.OrganizationId.ToString()) && searchParam.OrganizationId != -1)
                { units = units.Where(ob => ob.US.locationid == searchParam.OrganizationId);
                    MeterNotReceived = MeterNotReceived.Where(ob => ob.locationid== searchParam.OrganizationId);
                }
           }





            var unitsPrevDay = from us in UnitSummary
                               join ucd in UnitsConsumptionDetails
                               on us.id equals ucd.unitid
                               where ucd.daterecorded == searchDate.AddDays(-1)
                               group new { US = us, UCD = ucd } by us.unitid
                                into g
                               select g.OrderByDescending(m => m.UCD.consumptioninmcube).FirstOrDefault();
            // select new { US = us, UCD = ucd };

            var unitsUpdated = from us in units
                               join usp in unitsPrevDay
                               on us.UCD.unitid equals usp.UCD.unitid into rec 
                               from r in rec.DefaultIfEmpty() 
                               select new {US = us.US, UCD = us.UCD,
                                   id = us.UCD.unitid,
                                   consumption = us.UCD.consumptioninmcube - (r==null ?0: r.UCD.consumptioninmcube ),
                               previousDayConsumption = (r == null ? 0 : r.UCD.consumptioninmcube)
                               };

            var unitsUpdatedNotReceived = from us in MeterNotReceived
                               join usp in unitsPrevDay
                               on us.id equals usp.UCD.unitid into rec
                               from r in rec.DefaultIfEmpty()
                               select new
                               {
                                   US = us,
                                   //UCD = r.UCD,
                                   id = us.id,
                                   consumption =0,
                                   previousDayConsumption = (r == null ? 0 : r.UCD.consumptioninmcube)
                               };

            //unitsUpdated.ForEachAsync(m => m.UCD.consumptioninmcube = m.consumption).RunSynchronously();
            var updated = unitsUpdated.ToList();
            foreach (var unUpt in updated)
            {
                unUpt.UCD.consumptioninmcube = unUpt.consumption;
                unUpt.UCD.dayconsumption = unUpt.previousDayConsumption;
            }
            var updatedNotReceived = unitsUpdatedNotReceived.ToList();
            //foreach (var unUpt in updatedNotReceived)
            //{
            //    //unUpt.UCD.consumptioninmcube = unUpt.consumption;
            //    unUpt. .UCD.dayconsumption = unUpt.previousDayConsumption;
            //}
            var res = from u in updated
                      join org1 in Organization
                      on u.US.divisionid equals org1.organizationid
                      join org2 in Organization
                      on u.US.subdivisionid equals org2.organizationid
                      join org3 in Organization
                      on u.US.locationid equals org3.organizationid
                      join org4 in Organization
                      on u.US.servicestnid equals org4.organizationid
                      select new { US = u.US, UCD = u.UCD, Division = org1.organizationname, SubDivision = org2.organizationname, 
                      Location = org3.organizationname, ServiceStation = org4.organizationname };

            var res1 = from u in updatedNotReceived
                       join org1 in Organization
                       on u.US.divisionid equals org1.organizationid
                       join org2 in Organization
                       on u.US.subdivisionid equals org2.organizationid
                       join org3 in Organization
                       on u.US.locationid equals org3.organizationid
                       join org4 in Organization
                       on u.US.servicestnid equals org4.organizationid
                       select new
                       {
                           US = u.US,
                          // UCD = u.UCD,
                           DayConsumption = u.previousDayConsumption,
                           Division = org1.organizationname,
                           SubDivision = org2.organizationname,
                           Location = org3.organizationname,
                           ServiceStation = org4.organizationname
                       };
            //var res1 = from u in MeterNotReceived
            //          join org1 in Organization
            //          on u.divisionid equals org1.organizationid
            //          join org2 in Organization
            //          on u.subdivisionid equals org2.organizationid
            //          join org3 in Organization
            //          on u.locationid equals org3.organizationid
            //          join org4 in Organization
            //          on u.servicestnid equals org4.organizationid
            //          select new
            //          {
            //              US = u,
            //              Division = org1.organizationname,
            //              SubDivision = org2.organizationname,
            //              Location = org3.organizationname,
            //              ServiceStation = org4.organizationname
            //          };

            var finReceived = from row in res
                      join ms in Message_Data
                      on row.UCD.messagedataid equals ms.id
                      join emp in Employee 
                      on row.US.consumerid equals emp.employeeid into empr
                      from empl in empr.DefaultIfEmpty()
                      join kv in MasterValue 
                      on row.US.oemname equals kv.code 
                      join m in Masters
                      on kv.mastersid equals m.mastersid
                      where m.code == "MtrOEMName"
                      select new UnitConsumption()
                      {
                          id = row.US.id,
                          unitid = row.US.unitid,
                          pipesize = row.US.pipesizenew, 
                          rrnumber = empl== null ?"":empl.rrnumber, 
                          name = empl==null ?"":empl.firstname + empl.lastname, 
                          batteryvoltage = ms.batteryvoltage.ToString(),
                          consumptioninmcube = row.UCD.consumptioninmcube.ToString(),
                          dayconsumption = row.UCD.dayconsumption.ToString(),
                          division = row.Division,
                          subdivision = row.SubDivision,
                          location = row.Location, 
                          oemname = kv.description, AddedAt = row.UCD.addedat
                          , NotReceivedToday = false
                          
                      };
            var notReceived = from row in res1
                              select new UnitConsumption()
                              {
                                  id = row.US.id,
                                  unitid = row.US.unitid,
                                  pipesize = row.US.pipesizenew,
                                  division = row.Division,
                                  subdivision = row.SubDivision,
                                  location = row.Location,
                                  dayconsumption = row.DayConsumption==0?"": row.DayConsumption.ToString(),
                                  NotReceivedToday = true
                              };
            var fin = finReceived.ToList();
            fin.AddRange(notReceived.ToList());

            //var fina = from r in fin
            //           group r by r.unitid into g
            //           let maxcons = g.Max(o => o.consumptioninmcube)
            //           select g.FirstOrDefault(o => o.consumptioninmcube == maxcons) ;

            result.TotalRecords = fin.Count();
            if (string.IsNullOrEmpty(pagedInput.SortBy)) {

                pagedInput.SortBy = "unitid";
                pagedInput.SortAsc = true;
            }
            result.Data = AllRecords ? fin.GetOrderBy<UnitConsumption>(pagedInput.SortBy, pagedInput.SortAsc).ToList() 
                : fin.GetOrderBy<UnitConsumption>(pagedInput.SortBy, pagedInput.SortAsc).Skip(start).Take(next).ToList();
            //result.Data = AllRecords ? fina.ToList() : fina.Skip(start).Take(next).ToList();
            return result;
            //string criteria = string.Format("{0},{1},'{2}','{3}','{4}'", input.UserId, input.RoleId, input.OEM, input.Organization, input.Designation);
            //string sp = "getbindgridontodaysdate1";
            //string query =  DbUtility.GetSPName(this.ProviderName, sp, criteria);
            //if (searchParam != null)
            //{
            //    sp = "getbindgridontodaysdate2";
            //    criteria = string.Format("{0},{1},'{2}','{3}','{4}',{5},'{6}','{7}','{8}'", input.UserId, input.RoleId, input.OEM, input.Organization, input.Designation,
            //                                                                                searchParam.OrganizationId, searchParam.RRnumber, searchParam.OEM, searchParam.Date);
            //    query = DbUtility.GetSPName(this.ProviderName, sp, criteria);
            //}
            //result.TotalRecords = this.UnitConsumptionRows.FromSql<UnitConsumption>(query).Count();
            //if (string.IsNullOrWhiteSpace(pagedInput.SortBy))
            //    pagedInput.SortBy = "unitid";

            ////var qry = this.UnitConsumptionRows.FromSql<UnitConsumption>(query).GetOrderBy<UnitConsumption>(pagedInput.SortBy, pagedInput.SortAsc) ;


            //// var r = typeof(UnitConsumption).GetProperty(pagedInput.SortBy);
            //// var paramExpr = Expression.Parameter(typeof(UnitConsumption));
            //// var prop = Expression.PropertyOrField(paramExpr, r.Name);
            //// var expr = Expression.Lambda(prop, paramExpr);
            //// var method = typeof(Enumerable).GetMethods().FirstOrDefault(m => m.Name == "OrderBy" && m.GetParameters().Length == 2);
            //// var gm = method.MakeGenericMethod(typeof(UnitConsumption), r.PropertyType);


            ////var res=  gm.Invoke(null, new object[] { qry, expr.Compile() });
            ////            LambdaExpression sort = Expression.Lambda(r,)

            ////if (pagedInput.SortAsc)
            ////    qry.OrderBy(m => r.GetValue(m, null));
            ////else
            ////    qry.OrderByDescending(m => r.GetValue(m, null));

            //if (AllRecords)
            //    result.Data=  this.UnitConsumptionRows.FromSql<UnitConsumption>(query).GetOrderBy<UnitConsumption>(pagedInput.SortBy, pagedInput.SortAsc);
            //else
            //    result.Data = this.UnitConsumptionRows.FromSql<UnitConsumption>(query).GetOrderBy<UnitConsumption>(pagedInput.SortBy, pagedInput.SortAsc).Skip(start).Take(next);
            ////if (AllRecords)
            ////    result.Data = this.UnitConsumptionRows.FromSql<UnitConsumption>(query).OrderBy(m => r.GetValue(m, null));
            ////else
            ////    result.Data = this.UnitConsumptionRows.FromSql<UnitConsumption>(query).Skip(start).Take(next);
            //return result;

        }
        
        public UnitConsumptionSearch GetUnitConsumptionSearch(GenericRequest input)
        {
            var result = new UnitConsumptionSearch();
            ////result.Organizations = new List<Organization>();

            //string criteria = string.Format("{0},{1},'{2}','{3}','{4}'", input.UserId, input.RoleId, input.OEM, input.Organization, input.Designation);
            //string sp = "getorganizationlist";
            //string query=  DbUtility.GetSPName(this.ProviderName, sp, criteria);
            //var orgs = this.OrganizationRows.FromSql<db_KeyValuePair>(query, input.UserId, input.RoleId, input.OEM, input.Organization, input.Designation);
            //sp = "getrrnumbers";
            //query = DbUtility.GetSPName(this.ProviderName, sp, criteria);
            //var rrnumbers  = this.RRNumberRows.FromSql<db_KeyValuePair_Text>(query, input.UserId, input.RoleId, input.OEM, input.Organization, input.Designation);

            //sp = "getmasterdata";
            //query = DbUtility.GetSPName(this.ProviderName, sp, string.Format("'{0}'","MtrOEMName"));
            //var masterdata = this.OEM.FromSql<MasterData>(query, input.UserId, input.RoleId, input.OEM, input.Organization, input.Designation);
            var user = (from em in Employee
                        where em.employeeid == input.UserId
                        select em).FirstOrDefault();

            var orgs = from org in Organization
                       where org.organizationtypeid == 3
                       select org;
            if (user.heads == "D")
                orgs = from org in orgs
                       join us in UnitSummary on org.organizationid equals us.locationid
                       where us.divisionid == user.divisionid
                       select org;
            if (user.heads == "SD")
                orgs = from org in orgs
                       join us in UnitSummary on org.organizationid equals us.locationid
                       where us.subdivisionid == user.subdivisionid
                       select org;

            var allorgs = (from org in orgs 
                                   select new db_KeyValuePair { Key = (int)org.organizationid, Value = org.organizationname });
            result.Organizations = allorgs.GroupBy(o => o.Key).Select(g => g.First());

//            result.RRNumbers = rrnumbers;
//          result.OEM = masterdata;
            return result;
        }
        public UnitConsumptionGraph<string> GetGraph(GenericRequest input, SearchParam criteria)
        {
            PagedData<GenericRequest> inp = new PagedData<GenericRequest>();
            inp.NumberOfRecords = -1;
            inp.Data = input;
            var fullData = this.GetTodayData(inp, criteria);
            var first = fullData.Data.Where(m => m.consumptioninmcube != null && m.consumptioninmcube.Trim() != "" && m.consumptioninmcube.Trim() != "N/C" && m.consumptioninmcube.Trim() != "###")
                            .Select(us =>  new point<string>() { X = us.unitid, Y = Convert.ToDecimal(us.consumptioninmcube)  });
            var second = fullData.Data.Where(m =>m.dayconsumption!= null &&   m.dayconsumption.Trim() != "" && m.dayconsumption.Trim() != "N/C" && m.dayconsumption.Trim() !="###")
                            .Select(us => new point<string>() { X = us.unitid, Y = Convert.ToDecimal(us.dayconsumption) });
            var result = new UnitConsumptionGraph<string>();
            result.Cumalative = new Graph<string>();
            result.DayConsumption = new Graph<string>();
            result.Cumalative.Data = first.ToList();
            result.DayConsumption.Data = second.ToList();
            return result;
        }

        public PagedResponse<UnitConsumptionHistory> GetHistoryforUnit(PagedData<UnitConsumptionHistoryInput> input)
        {
            bool AllRecords = false;
            var result = new PagedResponse<UnitConsumptionHistory>();
            var start = input.PageNumber.HasValue ? input.PageNumber.Value : 1;
            var next = input.NumberOfRecords.HasValue ? input.NumberOfRecords.Value : 20;
            AllRecords = (next == -1);
            start = (start - 1) * next;
            var query = from msg in Message_Data
                        join us in UnitSummary on msg.unitid equals us.id
                        join kv in MasterValue
                    on us.oemname equals kv.code
                        join m in Masters
                        on kv.mastersid equals m.mastersid
                        where m.code == "MtrOEMName" && 
                        msg.unitid == input.Data.UnitId
                        select new UnitConsumptionHistory
                        {
                            id = msg.id,
                            unitid = us.unitid,
                            batteryvoltage = msg.batteryvoltage,
                            consumptioninmcube = msg.cumconsumpofprevday,
                            PulseCount= msg.cumconsumpofprevtoprevday,
                            date = msg.date,
                            time = msg.time.ToString(),
                            oemname = kv.description , 
                            TamperStatus = msg.tamperstatus
                            
                        };
            query = query.OrderByDescending(m => m.date).ThenByDescending(m => m.time);
            result.TotalRecords = query.Count();
            result.Data = AllRecords ? query.ToList() : query.Skip(start).Take(next).ToList();
            return result;
            //if (AllRecords)
            //    result.Data = this.HistoryUnitRows.FromSql<UnitConsumptionHistory>(query);
            //else
            //    result.Data = this.HistoryUnitRows.FromSql<UnitConsumptionHistory>(query).Skip(start).Take(next);
            //return result;

            //string criteria = string.Format("{0},{1}", input.Data.UnitId, input.Data.Role);
            //string sp = "gethistorydetailsforunit";
            //string query = DbUtility.GetSPName(this.ProviderName, sp, criteria);
            //result.TotalRecords = this.HistoryUnitRows.FromSql<UnitConsumptionHistory>(query).Count();
            //if (AllRecords)
            //    result.Data = this.HistoryUnitRows.FromSql<UnitConsumptionHistory>(query);
            //else
            //    result.Data = this.HistoryUnitRows.FromSql<UnitConsumptionHistory>(query).Skip(start).Take(next);
            //return result;
        }
        public UnitConsumptionGraph<DateTime> GetHistoryGraph(UnitConsumptionHistoryInput input)
        {
            PagedData<UnitConsumptionHistoryInput> inp = new PagedData<UnitConsumptionHistoryInput>();
            inp.NumberOfRecords = -1;
            inp.Data = input;
            var fullData = this.GetHistoryforUnit(inp);
            var first = fullData.Data.Select(us => new point<DateTime>() { X = us.date, Y = Convert.ToDecimal(us.consumptioninmcube) });
            var second = fullData.Data.Select(us => new point<DateTime>() { X = us.date, Y = Convert.ToDecimal(us.PulseCount) });
            var result = new UnitConsumptionGraph<DateTime>();
            result.Cumalative = new Graph<DateTime>();
            result.DayConsumption = new Graph<DateTime>();
            result.Cumalative.Data = first.ToList();
            result.DayConsumption.Data = second.ToList();
            return result;
        }
        public PagedResponse<DataModels.UnitSummary.MessageRejected> GetRejectedMessages(PagedData<DataModels.UnitSummary.MessageRejectedInput> input)
        {
            bool AllRecords = false;
            var result = new PagedResponse<DataModels.UnitSummary.MessageRejected>();
            var start = input.PageNumber.HasValue ? input.PageNumber.Value : 1;
            var next = input.NumberOfRecords.HasValue ? input.NumberOfRecords.Value : 20;
            AllRecords = (next == -1);
            start = (start - 1) * next;

            var query = from mr in MessageRejected
                        select mr;
            result.TotalRecords = query.Count();
            result.Data = AllRecords ? query.ToList() : query.Skip(start).Take(next).ToList();
            return result;

        }

    }
}
