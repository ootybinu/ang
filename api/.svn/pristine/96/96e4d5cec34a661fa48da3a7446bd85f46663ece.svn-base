using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using WaterAMR.DataRepository;
using WaterAMR.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using WaterAMR.DataModels.UnitSummary;
using WaterAMR.DataModels.Dashboard;
using WaterAMR.DataModels.Organization;
using WaterAMR.DataModels.Oem;
using WaterAMR.DataModels.User;
using WaterAMR.DataModels.Role;

namespace WaterAMR.DataAccess
{
    public class DashboardRepository : DataStore, IDashboardRepository
    {
        private DbSet<UnitsConsumptionDetails> UnitsConsumptionDetails { get; set; }
        private DbSet<UnitSummary> UnitSummary { get; set; }
        private DbSet<Organization> Organization { get; set; }
        private DbSet<Oem> MasterValue { get; set; }
        private DbSet<masters> Masters { get; set; }
        private DbSet<message_data> Message_Data { get; set; }
        private DbSet<ftp_data> FTP_Data { get; set; }
        private DbSet<employee> Employee { get; set; }
        private DbSet<employeeloginmapping> EmployeeLoginMap { get; set; }
        private DbSet<loginmaster> LoginMaster{ get; set; }
        private DbSet<Role> Roles { get; set; }
        public DashboardRepository(IConfiguration configHelper) : base(configHelper)
        {
        }

        public ConsumptionData GetConsumptionData(ConsumptionInput input)
        {
            var from = input.From.Split('-');
            var to = input.To.Split('-');
            var fromDate = new DateTime(Convert.ToInt32(from[0]), Convert.ToInt32(from[1]), 1);
            var lastday = DateTime.DaysInMonth(Convert.ToInt32(to[0]), Convert.ToInt32(to[1]));
            var toDate = new DateTime(Convert.ToInt32(to[0]), Convert.ToInt32(to[1]), lastday);

            var result = new ConsumptionData();
            var result1 = new List< KeyValuePair<string,List< KeyValuePair<string, decimal>>>>();
            var result2 = new List<KeyValuePair<string, List<KeyValuePair<string, decimal>>>>();
            
            var isAdmin = false;
            var user = (from emp in Employee
                        join el in EmployeeLoginMap
                        on emp.employeeid equals el.employeeid
                        join lm in LoginMaster
                        on el.loginname equals lm.loginname
                        join rol in Roles
                        on lm.roles equals rol.roleid
                        where emp.employeeid == input.UserId
                        select rol.rolename).FirstOrDefault();
            isAdmin = user == "Admin";
            IQueryable<ConsumptionResult> qry;
            if (isAdmin)
            {
                qry = from ucd in UnitsConsumptionDetails
                          join us in UnitSummary
                          on ucd.unitid equals us.id
                          where ucd.daterecorded <= toDate &&
                          ucd.daterecorded >= fromDate
                          //where ucd.daterecorded >= DateTime.Now.AddYears(-1)
                          orderby ucd.daterecorded
                          group ucd by new { Month = ucd.daterecorded.Month, Year = ucd.daterecorded.Year, unitId = us.unitid } into d
                          select new ConsumptionResult { period = new DateTime(d.Key.Year, d.Key.Month, 1), month = d.Key.Month, year = d.Key.Year, unitid = d.Key.unitId, consumption = d.Max(c => c.consumptioninmcube) - d.Min(e => e.consumptioninmcube) }
                            ;

            }
            else
            {
                qry = from ucd in UnitsConsumptionDetails
                      join us in UnitSummary
                      on ucd.unitid equals us.id
                      where ucd.daterecorded <= toDate &&
                      ucd.daterecorded >= fromDate && 
                      us.consumerid == input.UserId
                      //where ucd.daterecorded >= DateTime.Now.AddYears(-1)
                      orderby ucd.daterecorded
                      group ucd by new { Month = ucd.daterecorded.Month, Year = ucd.daterecorded.Year, unitId = us.unitid } into d
                      select new ConsumptionResult { period = new DateTime(d.Key.Year, d.Key.Month, 1), month = d.Key.Month, year = d.Key.Year, unitid = d.Key.unitId, consumption = d.Max(c => c.consumptioninmcube) - d.Min(e => e.consumptioninmcube) }
                            ;
            }

            var distinctRows = (from m in qry
                               select m.unitid).Distinct()
                               ;
            foreach (var dr in distinctRows)
            {
                
                var sub = from row in qry
                          where row.unitid == dr
                          select new KeyValuePair<string, decimal>(row.period.ToString("MMM-yyyy"), row.consumption);

                var r1 = new KeyValuePair<string, List<KeyValuePair<string, decimal>>>(dr.ToString(), sub.ToList());
                result1.Add(r1);
            }

            var distinctRows1 = (from m in qry
                                select m.period).Distinct()
                   ;
            foreach (var dr in distinctRows1)
            {

                var sub = from row in qry
                          where row.period == dr
                          select new KeyValuePair<string, decimal>(row.unitid, row.consumption);

                var r1 = new KeyValuePair<string, List<KeyValuePair<string, decimal>>>(dr.ToString("MMM-yyyy"), sub.ToList());
                result2.Add(r1);
            }

            result.Data = result1;
            result.AlternateData = result2;
            return result;
        }
        public List<KeyValuePair<string, decimal>> GetDivisionWise(ConsumptionInput input)
        {
            var from = input.From.Split('-');
            var to = input.To.Split('-');
            var fromDate = new DateTime(Convert.ToInt32(from[0]), Convert.ToInt32(from[1]), 1);
            var lastday = DateTime.DaysInMonth(Convert.ToInt32(to[0]), Convert.ToInt32(to[1]));
            var toDate = new DateTime(Convert.ToInt32(to[0]), Convert.ToInt32(to[1]), lastday);

            var result = new List<KeyValuePair<string, decimal>>();
            var isAdmin = false;
            var user = (from emp in Employee
                        join el in EmployeeLoginMap
                        on emp.employeeid equals el.employeeid
                        join lm in LoginMaster
                        on el.loginname equals lm.loginname
                        join rol in Roles
                        on lm.roles equals rol.roleid
                        where emp.employeeid == input.UserId
                        select rol.rolename).FirstOrDefault();
            isAdmin = user == "Admin";
            IQueryable<KeyValuePair<String,decimal>> qry;
            if (isAdmin)
            {
                qry = from ucd in UnitsConsumptionDetails
                      join us in UnitSummary
                        on ucd.unitid equals us.id
                      join org in Organization
                      on us.divisionid equals org.organizationid

                      where ucd.daterecorded >= fromDate && ucd.daterecorded <= toDate
                      group ucd by new { Name = org.organizationname } into d
                      select new KeyValuePair<string, decimal>(d.Key.Name, d.Max(c => c.consumptioninmcube) - d.Min(c => c.consumptioninmcube));
            }
            else
            {
                qry = from ucd in UnitsConsumptionDetails
                      join us in UnitSummary
                        on ucd.unitid equals us.id
                      join org in Organization
                      on us.divisionid equals org.organizationid

                      where ucd.daterecorded >= fromDate && ucd.daterecorded <= toDate && us.consumerid == input.UserId
                      group ucd by new { Name = org.organizationname } into d
                      select new KeyValuePair<string, decimal>(d.Key.Name, d.Max(c => c.consumptioninmcube) - d.Min(c => c.consumptioninmcube));
            }
            return qry.ToList();
                     

        }

        public List<KeyValuePair<string, decimal>> GetOemWise(ConsumptionInput input)
        {
            var from = input.From.Split('-');
            var to = input.To.Split('-');
            var fromDate = new DateTime(Convert.ToInt32(from[0]), Convert.ToInt32(from[1]), 1);
            var lastday = DateTime.DaysInMonth(Convert.ToInt32(to[0]), Convert.ToInt32(to[1]));
            var toDate = new DateTime(Convert.ToInt32(to[0]), Convert.ToInt32(to[1]), lastday);

            var result = new List<KeyValuePair<string, decimal>>();
            var qry = from ucd in UnitsConsumptionDetails
                      join us in UnitSummary
                        on ucd.unitid equals us.id
                      join mv in MasterValue
                      on us.oemname equals mv.code   
                      join mas in Masters
                      on mv.mastersid  equals mas.mastersid where mas.code == "MtrOEMName"
                      where ucd.daterecorded >= fromDate && ucd.daterecorded <= toDate
                      group ucd by mas.description into d
                      select new KeyValuePair<string, decimal>(d.Key, d.Max(c => c.consumptioninmcube) - d.Min(c => c.consumptioninmcube));
            return qry.ToList();
        }
        public List<KeyValuePair<string, string>> GetMessageData(ConsumptionInput input)
        {
            var msg1 = (from msg in Message_Data
                        orderby msg.id descending
                        select new { Data = msg.date.ToString("dd-MM-yyyy") + " " + msg.time.ToString(@"hh\:mm") }).FirstOrDefault();

            //var msg2 = (from ftp in FTP_Data
            //            orderby ftp.id descending
            //            select ftp.readdatetime).FirstOrDefault();

            var msg3 = (from m in Message_Data
                        where m.tamperstatus != 0
                        select m).Count();

            //var msg4 = (from m in FTP_Data
            //            where m.alarms != null
            //            select m).Count();
            var result = new List<KeyValuePair<String, string>>();
            var ms1 = msg1 == null ? "" : msg1.Data;
            result.Add(new KeyValuePair<string, string>("Last Message Received at",ms1));
            //result.Add(new KeyValuePair<string, string>("Last File Received at", msg2.ToString("dd-MM-yyyy hh:mm")));
            result.Add(new KeyValuePair<string, string>("Number of instances with Tamper Status", msg3.ToString()));
            //result.Add(new KeyValuePair<string, string>("Number of instances with Alarms Status", msg4.ToString()));
            return result;

        }
    }
}
