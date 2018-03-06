using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WaterAMR.DataModels.Security;

namespace WaterAMR.DataModels.Role
{
    [Table("roles")]
    public class Role
    {
        [Key]
        public long roleid { get; set; }
        public string rolename { get; set; }
        public string description { get; set; }
        public bool active { get; set; }
        public bool candelete { get; set; }
    }
    [Table("menumaster")]
    public class Menu {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public int ParentMenuId { get; set; }
        public Boolean HasChildren{ get; set; }
        public int MenuOrder { get; set; }
        public string Url { get; set; }
        public string DetailText { get; set; }
        public Boolean ShowInMenu { get; set; }
        public int MenuLevel { get; set; }
        public Boolean Active { get; set; }
        public string IconPath { get; set; }
        public Boolean ShowOnlyIcon { get; set; }
    }



    public class menu
    {
        [Key]
        public long menuid { get; set; }
        public string menuname { get; set; }
        public string menudescription { get; set; }
        public string iconpath { get; set; }

    }
    public class RoleResponse
    {
        //public IEnumerable<menu> AppMenu { get; set; }
        //public IEnumerable<menu> AppMenuRestricted { get; set; }
        //public IEnumerable<menu> AdminMenu { get; set; }
        //public IEnumerable<menu> AdminMenuRestricted { get; set; }
        public Role Role { get; set; }
        public MenuTree MenuTree { get; set; }
        public IEnumerable<menuprivileges> Privileges { get; set; }
    }
    [Table("menuprivileges")]
    public class menuprivileges
    {
        [Key]
        public long id { get; set; }
        public long menuid { get; set; }
        public long roleid { get; set; }
        public Int32 allowedto { get; set; }
        public DateTime validtill { get; set; }
    }
}
