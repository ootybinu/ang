using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using WaterAMR.DataAccess.Interfaces;
using WaterAMR.DataModels;
using WaterAMR.DataModels.Role;
using WaterAMR.DataRepository;
using Microsoft.EntityFrameworkCore;
using WaterAMR.DataModels.Security;

namespace WaterAMR.DataAccess
{
    public class RoleRepository : DataStore, IRoleRepository
    {
        private DbSet<Role> Roles { get; set; }
        private DbSet<Menu> MenuMaster { get; set; }
        private DbSet<menu> menus { get; set; }
        private DbSet<menuprivileges> menuprivileges{ get; set; }

        public RoleRepository(IConfiguration configHelper) : base(configHelper)
        {
        }

        public PagedResponse<Role> GetAll(PagedData<SearchCriteria> pagedInput)
        {
            bool AllRecords = false;
            var input = pagedInput.Data;
            var result = new PagedResponse<Role>();

            var start = pagedInput.PageNumber.HasValue ? pagedInput.PageNumber.Value : 1;
            var next = pagedInput.NumberOfRecords.HasValue ? pagedInput.NumberOfRecords.Value : 20;
            AllRecords = (next == -1);
            start = (start - 1) * next;
            result.TotalRecords = this.Roles.Count();// FromSql<Role>(qry).Count();
            if (AllRecords)
                result.Data = this.Roles;// .FromSql<Role>(qry);
            else
                result.Data = this.Roles.Skip(start).Take(next);
            return result;
        }

        public RoleResponse GetRole(int id)
        {
            if (id == -1)
            {
                return getInitialData();
            }


            var result = new RoleResponse();
            //string qry = string.Format("select mm.menuid, menuname, menudescription, iconpath from menuprivileges mp inner join  menumaster mm " +
            //    " on mm.menuid = mp.menuid where mp.roleid={0} and mm.parentmenuid in (select menuid from menumaster where menuname='apps')", id);
            //result.AppMenu = this.menus.FromSql<menu>(qry);

            //qry = string.Format("select menuid, menuname, menudescription, iconpath from menumaster where menuid not in (select menuid from menuprivileges  " + 
            //    "where roleid={0}) and parentmenuid in (select menuid from menumaster where menuname ='apps') ", id);
            //result.AppMenuRestricted = this.menus.FromSql<menu>(qry);

            //qry = string.Format("select mm.menuid, menuname, menudescription, iconpath from menuprivileges mp inner join  menumaster mm " +
            //    " on mm.menuid = mp.menuid where mp.roleid={0} and mm.parentmenuid in (select menuid from menumaster where menuname='admin')", id);
            //result.AdminMenu = this.menus.FromSql<menu>(qry);

            //qry = string.Format("select menuid, menuname, menudescription, iconpath from menumaster where menuid not in (select menuid from menuprivileges  " +
            //    "where roleid={0}) and parentmenuid in (select menuid from menumaster where menuname ='admin') ", id);
            //result.AdminMenuRestricted = this.menus.FromSql<menu>(qry);

            result.Role = Roles.Where(ob => ob.roleid == id).FirstOrDefault();
            result.Privileges = menuprivileges.Where(ob => ob.roleid == id).ToList();
            return result;
            
        }

        private RoleResponse getInitialData()
        {
            var result = new RoleResponse();
            //string qry = "select menuid, menuname, menudescription, iconpath from menumaster where parentmenuid in (select menuid from menumaster where menuname ='apps')";
            //result.AppMenu = this.menus.FromSql<menu>(qry);
            //qry = "select menuid, menuname, menudescription, iconpath from menumaster where parentmenuid in (select menuid from menumaster where menuname ='admin')";
            //result.AdminMenuRestricted = this.menus.FromSql<menu>(qry);
            //result.AppMenuRestricted = new List<menu>();
            //result.AdminMenu = new List<menu>();
            result.Privileges = menuprivileges.Where(ob => ob.roleid == 1).ToList();
            return result;
        }

        public  bool UpdateRole(RoleResponse update)
        {
            var flag = true;
            if (update.Role.roleid == 0)
            {
                this.Roles.Add(update.Role);
                // Add here 
            }
            else
            {
                this.Roles.Update(update.Role);
            }
            this.SaveChanges();
            var delqry = menuprivileges.Where(ob => ob.roleid == update.Role.roleid);
            var date = delqry.Any() ? delqry.First().validtill : DateTime.Now.AddYears(10).Date;
            foreach (var item in delqry)
            {
                menuprivileges.Remove(item);
            }
            this.SaveChanges();
            if (update.MenuTree != null)
            {
                Addprivilege(update.MenuTree.SubMenu, update.Role.roleid, date);
                //            menuprivileges.AddRange(update.Privileges);
                this.SaveChanges();
            }
            //string qry = string.Format("delete from menuprivileges where roleid ={0}",update.Role.roleid );
            //this.Database.ExecuteSqlCommand(qry);

            //foreach (var item in update.AdminMenu)
            //    {
            //        var mp = new menuprivileges();
            //        mp.menuid = item.menuid;
            //        mp.roleid = update.Role.roleid;
            //        mp.validtill = Convert.ToDateTime("2030-12-31");
            //        mp.allowedto = 7;
            //        this.menuprivileges.Add(mp);
            //    }
            //foreach (var item in update.AppMenu)
            //{
            //    var mp = new menuprivileges();
            //    mp.menuid = item.menuid;
            //    mp.roleid = update.Role.roleid;
            //    mp.validtill = Convert.ToDateTime("2030-12-31");
            //    mp.allowedto = 7;
            //    this.menuprivileges.Add(mp);
            //}
            //this.SaveChanges();
            
            return flag;
        }

        private void Addprivilege(List<MenuTree> subMenu, long roleId, DateTime validTill)
        {
            foreach (var item in subMenu)
            {
                var privilege = new menuprivileges();
                privilege.menuid = item.Menu.Id;
                privilege.roleid = roleId;
                privilege.validtill = validTill;
                privilege.allowedto = item.Privilege;
                this.menuprivileges.Add(privilege);
                Addprivilege(item.SubMenu, roleId, validTill);
            }
        }
    }
}
