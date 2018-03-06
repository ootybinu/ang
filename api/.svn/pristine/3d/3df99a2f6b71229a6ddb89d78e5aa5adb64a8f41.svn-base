using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WaterAMR.Business.Interfaces;
using WaterAMR.BusinessModels.Role;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WaterAMR.API.Controllers.Role
{
    [Route("api/[controller]")]
    public class UpdateRoleController : Controller
    {
        private IRoleService BusinessService;
        public UpdateRoleController(IRoleService service)
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

        //[Route("UpdateRole/{update}")]
        [HttpPost]
        public bool Post([FromBody] RoleResponse update)
        {
            return BusinessService.UpdateRole(update);
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
