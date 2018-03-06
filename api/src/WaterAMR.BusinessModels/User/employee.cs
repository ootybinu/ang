using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WaterAMR.BusinessModels.User
{
    public class employee
    {
        
        public long employeeid { get; set; }
        public string firstname { get; set; }
        public string midname { get; set; }
        public string lastname { get; set; }
        public Int32 logintype { get; set; }
        public string photograph { get; set; }
        public DateTime? dateofbirth { get; set; }
        public Int32? maritalstatus { get; set; }
        public Int32? sex { get; set; }
        public Int32 isapproved { get; set; }
        public DateTime? datecreated { get; set; }
        public Int32? usercreated { get; set; }
        public DateTime? datelastmodified { get; set; }
        public Int32? userlastmodified { get; set; }
        public string rrnumber { get; set; }
        public string address { get; set; }
        public string mobilenumber { get; set; }
        public string message { get; set; }
        public string email { get; set; }
        public string oem { get; set; }
        public string heads { get; set; }
        public string designation { get; set; }
        public Int32? divisionid { get; set; }
        public Int32? subdivisionid { get; set; }
        public string LandingPage { get; set; }
    }

    public class employeeloginmapping
    {
        public string loginname { get; set; }
        public long employeeid { get; set; }
    }
    public class loginmaster
    {
        public string loginname { get; set; }
        public string password { get; set; }
        public Int32 roles { get; set; }
        public bool active { get; set; }
        public Int32 loginfailedcount { get; set; }
        public bool firstlogininnew { get; set; }
        public long? defaultrole { get; set; }
    }

    public class employeeRow
    {
        public long employeeid { get; set; }
        public string loginname { get; set; }
        public string name { get; set; }
        public string rrnumber { get; set; }
        public string email { get; set; }
        public string mobilenumber { get; set; }
    }
    public class employeeFull
    {
        public employee emp { get; set; }
        public loginmaster emplog { get; set; }
    }

    public class employeeResponse
    {
        public employeeFull Data { get; set; }
        public IEnumerable<KeyValuePair<Int32,string>> Roles { get; set; }
        public IEnumerable<KeyValuePair<Int32, string>> Divisions { get; set; }
        public IEnumerable<KeyValuePair<Int32, string>> SubDivisions { get; set; }

    }

}
