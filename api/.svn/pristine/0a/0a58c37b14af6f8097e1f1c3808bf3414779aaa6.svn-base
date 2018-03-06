using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WaterAMR.Business.Interfaces;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WaterAMR.API.Controllers.User
{
    [Route("api/[controller]")]
    public class UpdateUserController : Controller
    {
        private IUserService BusinessService;
        public UpdateUserController(IUserService service)
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

        //[Route("UpdateUser/{emp}")]
        [HttpPost]
        public bool Post([FromBody]BusinessModels.User.employeeFull emp)
        {
            if (emp.emp.employeeid == 0)
            {
                emp.emplog.password = Utility.Security.EncrptPassword(emp.emplog.loginname.ToLower() + emp.emplog.password);
            }
            return BusinessService.UpdateUser(emp);
        }

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
