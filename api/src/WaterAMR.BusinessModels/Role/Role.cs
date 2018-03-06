using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterAMR.BusinessModels.Security;

namespace WaterAMR.BusinessModels.Role
{
    public class Role
    {
        public long roleid { get; set; }
        public string rolename { get; set; }
        public string description { get; set; }
        public bool active { get; set; }
        public bool candelete { get; set; }
    }
    public class menu
    {
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
    public class menuprivileges
    {
        public long id { get; set; }
        public long menuid { get; set; }
        public long roleid { get; set; }
        public Int32 allowedto { get; set; }
        public DateTime validtill { get; set; }
    }
}
