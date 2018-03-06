using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using WaterAMR.DataAccess.Interfaces;
using WaterAMR.DataModels.Security;
using WaterAMR.DataRepository;
using Microsoft.EntityFrameworkCore;
using WaterAMR.Utility;
using WaterAMR.DataModels.User;
using WaterAMR.DataModels.Role;

namespace WaterAMR.DataAccess
{
    public class SecurityRepository :DataStore, ISecurityRepository
    {
        private DbSet<User> User { get; set; }
        private DbSet<employee> Employee { get; set; }
        private DbSet<loginmaster> LoginMaster { get; set; }
        private DbSet<employeeloginmapping> EmpLoginMapping { get; set; }
        private DbSet<DataModels.Organization.OrgInfo> OrgInfo { get; set; }

        private DbSet<MenuItem> MenuItems { get; set; }
        private DbSet<Menu> MenuMaster { get; set; }
        private DbSet<menuprivileges> MenuPrivileges { get; set; }
        public SecurityRepository(IConfiguration configHelper) : base(configHelper)
        {
        }
        public AuthenticationResult Authenticate(string userName, string password, string clientIP, string clientBrowser)
        {
            var result = new AuthenticationResult();
            var user = (from emp in Employee
                       join elm in EmpLoginMapping on emp.employeeid equals elm.employeeid
                       join lm in LoginMaster on elm.loginname equals lm.loginname
                       where lm.loginname == userName &&
                       lm.password == password
                       select new { Employee = emp, LogDetails = lm }).FirstOrDefault();

            if (user == null)
            {
                result.Message = "Invalid Credentials";
                return result;
            }

            var menus = from mn in MenuMaster
                        join mp in MenuPrivileges on mn.Id equals mp.menuid
                        where mp.roleid == user.LogDetails.roles && mp.validtill >= DateTime.Now
                        select new  Node{Menu= mn , Privilege= mp.allowedto} ;
            var tree = new MenuTree() { Privilege = 30 };

            tree.SubMenu = (from mn in menus
                            where mn.Menu.ParentMenuId == 0
                            orderby mn.Menu.MenuOrder
                            select new MenuTree() { Menu = mn.Menu, Privilege = mn.Privilege }).ToList();
            result.User = new DataModels.Security.User()
            {
                EmployeeId = (int)user.Employee.employeeid,
                Designation = user.Employee.designation,
                Heads = user.Employee.heads,
                LoginName = user.LogDetails.loginname,
                Name = user.Employee.firstname + user.Employee.lastname,
                OEM = user.Employee.oem,
                RoleId = user.LogDetails.roles,
                RRnumber = user.Employee.rrnumber, 
                LandingPage = user.Employee.LandingPage


            };
            result.OrgInfo = (from oi in OrgInfo
                              where oi.DivisionId == user.Employee.divisionid
                              select oi).FirstOrDefault();

            PopulateTree(menus, tree);
            result.MenuTree = tree;
            //string sp = "authenticate";
            //string criteria = string.Format("'{0}','{1}'", userName, password);

            //string query = DbUtility.GetSPName(this.ProviderName, sp, criteria);
            //var users = this.User.FromSql<User>(query);
            //if (users != null && users.Count() > 0)
            //{
            //    result.User = users.ToList()[0];
            //    sp = "getmenuforuser";
            //    criteria = string.Format("'{0}',{1}", userName, result.User.RoleId);
            //    query = DbUtility.GetSPName(this.ProviderName, sp, criteria);
            //    result.MenuItems = this.MenuItems.FromSql<MenuItem>(query);

            //    sp = "insertlogusage";
            //    criteria = string.Format("'{0}','{1}','{2}'", userName, clientIP, clientBrowser);
            //    query = DbUtility.GetSPName(this.ProviderName, sp, criteria);
            //    this.Database.ExecuteSqlCommand(query);
            //}
            //else
            //{
            //    result.Message = "Invalid Login";
            //}

            return result;
        }

        private void PopulateTree(IQueryable<Node> menus, MenuTree tree)
        {
            foreach (var item in tree.SubMenu)
            {
                var result = (from mn in menus
                              where mn.Menu.ParentMenuId == item.Menu.Id
                              orderby mn.Menu.MenuOrder
                              select new MenuTree() { Menu = mn.Menu, Privilege = mn.Privilege }).ToList();
                if (result == null)
                    continue;
                item.SubMenu = result;
                PopulateTree(menus, item);
            }
        }

        //public AuthenticationResult Authenticate(string userName, string password, string clientIP, string clientBrowser)
        //{
        //    var result = new AuthenticationResult();

        //    string sp = "authenticate";
        //    string criteria = string.Format("'{0}','{1}'", userName, password);

        //    string query = DbUtility.GetSPName(this.ProviderName, sp, criteria);
        //    var users = this.User.FromSql<User>(query);
        //    if (users != null && users.Count() >0 )
        //    {
        //        result.User = users.ToList()[0];
        //        sp = "getmenuforuser";
        //        criteria = string.Format("'{0}',{1}", userName, result.User.RoleId);
        //        query = DbUtility.GetSPName(this.ProviderName, sp, criteria);
        //        result.MenuItems = this.MenuItems.FromSql<MenuItem>(query);

        //        sp = "insertlogusage";
        //        criteria = string.Format("'{0}','{1}','{2}'", userName,clientIP, clientBrowser );
        //        query = DbUtility.GetSPName(this.ProviderName, sp, criteria);
        //        this.Database.ExecuteSqlCommand(query);
        //    }
        //    else
        //    {
        //        result.Message = "Invalid Login";
        //    }

        //    return result;
        //}
    }
}
