using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WaterAMR.BusinessModels.Security
{
    public class User
    {
        public int RoleId { get; set; }
        public string LoginName { get; set; }
        public Int32 EmployeeId { get; set; }
        public string Name { get; set; }
        public string RRnumber { get; set; }
        public string OEM { get; set; }
        public string Heads { get; set; }
        public string Designation  { get; set; }
        public string LandingPage { get; set; }
    }

    public class AuthenticationResult
    {
        public User User { get; set; }
        public IEnumerable<MenuItem> MenuItems { get; set; }
        public string Message { get; set; }
        public string TokenId { get; set; }
        public MenuTree MenuTree { get; set; }
        public Organization.OrgInfo OrgInfo { get; set; }

    }
    public class MenuTree
    {
        public Menu Menu { get; set; }
        public int Privilege { get; set; }
        public List<MenuTree> SubMenu { get; set; }
    }
}
