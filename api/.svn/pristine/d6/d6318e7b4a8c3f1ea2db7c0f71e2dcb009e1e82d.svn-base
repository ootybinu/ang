using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WaterAMR.BusinessModels;
using WaterAMR.Business.Interfaces;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WaterAMR.API.Controllers.User
{
    [Route("api/[controller]/[action]")]
    public class UserController : Controller
    {
        private IUserService BusinessService;
        public UserController(IUserService service)
        {
            BusinessService = service;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        //[Route("GetAllUsers/{value}")]
        //[HttpPost]
        //public PagedResponse<BusinessModels.User.employeeRow> GetAllUsers([FromBody]PagedData<BusinessModels.User.SearchCriteria> value)
        //{
        //    return BusinessService.GetAllUsers(value);
        //}
        //[Route("GetUser/{value}")]
        [HttpPost]
        public BusinessModels.User.employeeResponse GetUser([FromBody]Int32 value)
        {
            return BusinessService.GetUser(value);
        }

        [HttpPost]
        public IEnumerable<KeyValuePair<Int32,string>> GetOrganization()
        {
            return BusinessService.GetOrganization();
        }

        //[Route("UpdateUser/{emp}")]
        //[HttpPost]
        //public bool UpdateUser([FromBody]BusinessModels.User.employeeFull emp)
        //{
        //    if (emp.emp.employeeid == 0)
        //    {
        //        emp.emplog.password = Utility.Security.EncrptPassword(emp.emplog.loginname.ToLower() + emp.emplog.password);
        //    }
        //    return BusinessService.UpdateUser(emp);
        //}
        //[Route("UpdatePassword/{kv}")]
        //[HttpPost]
        //public bool UpdatePassword([FromBody]KeyValuePair<string,string> kv)
        //{
        //        var pwd  = Utility.Security.EncrptPassword(kv.Key.ToLower() + kv.Value);
        //    return BusinessService.UpdatePassword(kv.Key, pwd);

        //}
        //[Route("GetRoles")]
        //[HttpPost]
        //public IEnumerable<KeyValuePair<Int32,string>> GetRoles()
        //{
        //    return BusinessService.GetRoles();
        //}
        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
