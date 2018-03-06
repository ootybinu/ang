using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using WaterAMR.DataAccess.Interfaces;
using WaterAMR.DataModels;
using WaterAMR.DataModels.User;
using WaterAMR.DataRepository;
using Microsoft.EntityFrameworkCore;
using WaterAMR.DataModels.Organization;
using WaterAMR.Utility;
//using WaterAMR.DataModels.Role;

namespace WaterAMR.DataAccess
{
    public class UserRepository : DataStore, IUserRepository
    {
        //private DbSet<employeeRow> EmployeeRows { get; set; }
        //private DbSet<employeeFull> EmployeeFullRow { get; set; }
        private DbSet<employee> employee { get; set; }
        private DbSet<employeeloginmapping> employeeloginmapping { get; set; }
        private DbSet<loginmaster> loginmaster { get; set; }
        private DbSet<db_KeyValuePair> kv { get; set; }
        private DbSet<Organization> Organization { get; set; }
        private DbSet<WaterAMR.DataModels.Role.Role> Role { get; set; }
        private IUserInjection Context;
        public UserRepository(IConfiguration configHelper, IUserInjection userInjetion) : base(configHelper)
        {
            Context = userInjetion;
        }

        public PagedResponse<employeeRow> GetAllUsers(PagedData<SearchCriteria> pagedInput)
        {
            bool AllRecords = false;
            var input = pagedInput.Data;

            var start = pagedInput.PageNumber.HasValue ? pagedInput.PageNumber.Value : 1;
            var next = pagedInput.NumberOfRecords.HasValue ? pagedInput.NumberOfRecords.Value : 20;
            AllRecords = (next == -1);
            start = (start - 1) * next;
            var result = new PagedResponse<employeeRow>();
            var userid = Context.GetUser();
            var emplogged = (from empl in employee where empl.employeeid == userid select empl).FirstOrDefault();


            //var qry = from emp in employee
            //          join lmap in employeeloginmapping on emp.employeeid equals lmap.employeeid
            //          join lm in loginmaster on lmap.loginname equals lm.loginname
            //          select new employeeRow
            //          {
            //              email = emp.email,
            //              employeeid = emp.employeeid,
            //              loginname = lm.loginname,
            //              mobilenumber = emp.mobilenumber,
            //              name = emp.firstname + emp.lastname,
            //              rrnumber = emp.rrnumber
            //          };
            var qry = from emp in employee
                      join lmap in employeeloginmapping on emp.employeeid equals lmap.employeeid
                      join lm in loginmaster on lmap.loginname equals lm.loginname
                      select new { Emp = emp, Lm = lm };
            if (emplogged != null && emplogged.divisionid != null) {
                qry = from obj in qry
                      where obj.Emp.divisionid == emplogged.divisionid
                      select obj;
            }

            var innerResult = from obj in qry
                              select new employeeRow
                              {
                                  email = obj.Emp.email,
                                  employeeid = obj.Emp.employeeid,
                                  loginname = obj.Lm.loginname,
                                  mobilenumber = obj.Emp.mobilenumber,
                                  name = obj.Emp.firstname + obj.Emp.lastname,
                                  rrnumber = obj.Emp.rrnumber
                              };

            var sc = pagedInput.Data;
            result.TotalRecords = innerResult.Count();// this.EmployeeRows.FromSql<employeeRow>(query).Count();

            if (string.IsNullOrWhiteSpace(pagedInput.SortBy))
            {
                pagedInput.SortBy = "employeeid";
                pagedInput.SortAsc = false;
            }
            if (AllRecords)
                result.Data = innerResult.GetOrderBy<employeeRow>(pagedInput.SortBy, pagedInput.SortAsc);
            else
                result.Data = innerResult.GetOrderBy<employeeRow>(pagedInput.SortBy, pagedInput.SortAsc).Skip(start).Take(next);
            return result;
            //string query = "select e.employeeid,lm.loginname,  coalesce(e.firstname,'') || coalesce(e.midname,'') || coalesce(e.lastname) as name, " +
            //            " e.rrnumber, e.email, e.mobilenumber " +
            //            " from employee e inner join employeeloginmapping lm on e.employeeid = lm.employeeid ";
            //var start = pagedInput.PageNumber.HasValue ? pagedInput.PageNumber.Value : 1;
            //var next = pagedInput.NumberOfRecords.HasValue ? pagedInput.NumberOfRecords.Value : 20;
            //AllRecords = (next == -1);
            //start = (start - 1) * next;
            //var sc = pagedInput.Data;
            //result.TotalRecords = this.EmployeeRows.FromSql<employeeRow>(query).Count();
            //if (AllRecords)
            //    result.Data = this.EmployeeRows.FromSql<employeeRow>(query);
            //else
            //    result.Data = this.EmployeeRows.FromSql<employeeRow>(query).Skip(start).Take(next);
            //return result;
        }

        public employeeResponse GetUser(Int32 id)
        {
            var result = new employeeResponse();
            result.Data = new employeeFull();
            //string qry = string.Format("select e.* " +
            //    " from employee e inner join employeeloginmapping mp on e.employeeid = mp.employeeid " +
            //    " inner join loginmaster lm on lm.loginname = mp.loginname where e.employeeid ={0}", id);
            //result.Data.emp = this.employee.FromSql<employee>(qry).FirstOrDefault();
            //qry = string.Format("select lm.* " +
            //    " from employee e inner join employeeloginmapping mp on e.employeeid = mp.employeeid " +
            //    " inner join loginmaster lm on lm.loginname = mp.loginname where e.employeeid ={0}", id);
            //result.Data.emplog = this.loginmaster.FromSql<loginmaster>(qry).FirstOrDefault();

            //qry = "select roleid as Key, rolename as Value from roles where active = true";

            var both = (from emp in employee
                        join mp in employeeloginmapping
                        on emp.employeeid equals mp.employeeid
                        join lm in loginmaster
                        on mp.loginname equals lm.loginname
                        where emp.employeeid == id
                        select new { Emp = emp, LM = lm }).FirstOrDefault();
            if (both != null)
            {
                result.Data.emp = both.Emp;
                result.Data.emplog = both.LM;
                //result.Roles = this.kv.FromSql<db_KeyValuePair>(qry);
                result.Roles = (from role in Role
                                select new db_KeyValuePair { Key = (int)role.roleid, Value = role.rolename }).ToList();


            result.Divisions = (from org in Organization
                                where org.parentid == null
                                select new db_KeyValuePair { Key = (int)org.organizationid, Value = org.organizationname }).ToList();
                if (result.Data.emp.divisionid != null)
                {
                    result.SubDivisions = (from org in Organization
                                           where org.parentid == result.Data.emp.divisionid
                                           select new db_KeyValuePair { Key = (int)org.organizationid, Value = org.organizationname }).ToList();
                }
        }                
            return result;
        }

        public bool UpdateUser(employeeFull user)
        {
            bool flag = true;
            user.emp.heads = user.emp.divisionid != null ? "D" : "";
            if (user.emp.subdivisionid != null)
                user.emp.heads = "SD";
            if (user.emp.employeeid == 0)
            {
                user.emp.logintype = 2;
                this.employee.Add(user.emp);
                this.SaveChanges();
                var newid = user.emp.employeeid;
                var lm = new employeeloginmapping();
                lm.employeeid = newid;
                lm.loginname = user.emplog.loginname;
                this.employeeloginmapping.Add(lm);
                this.loginmaster.Add(user.emplog);
                this.SaveChanges();
            }
            else {
                this.employee.Update(user.emp);
                this.loginmaster.Update(user.emplog);
                this.SaveChanges();
            }
            return flag;
        }

        public IEnumerable<db_KeyValuePair> GetRoles()
        {
            var qry = from role in Role
                      where role.active == true
                      select new db_KeyValuePair { Key = (int)role.roleid, Value = role.rolename };
            return qry;
            //var qry = "select roleid as Key, rolename as Value from roles where active = true";
            //return  this.kv.FromSql<db_KeyValuePair>(qry);
        }

        public IEnumerable<db_KeyValuePair> GetOrganization()
        {
            var qry = (from org in Organization
                       where org.parentid == null
                       select new db_KeyValuePair { Key = (int)org.organizationid, Value = org.organizationname }).ToList();
            return qry;

        }
        public bool UpdatePassword(string username, string pwd)
        {
            var user = (from lm in loginmaster
                          where lm.loginname == username
                          select lm).FirstOrDefault();
            if (user != null)
                user.password = pwd;
            loginmaster.Update(user);
            this.SaveChanges();
            //var qry = string.Format("Update loginmaster set password = '{0}' where loginname='{1}'", pwd, username);
            //this.Database.ExecuteSqlCommand(qry);
            return true;
        }
    }
}
