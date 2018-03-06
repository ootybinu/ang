using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WaterAMR.Business.Interfaces;
using WaterAMR.BusinessModels.Organization;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WaterAMR.API.Controllers.Organization
{
    [Route("api/[controller]/[action]")]
    public class OrganizationController : Controller
    {
        IOrganizationService BusinessService; 
        public OrganizationController(IOrganizationService business)
        {
            BusinessService = business;
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
        [HttpPost]
        public IEnumerable<OrgShort> GetOrgMembers([FromBody]OrgInput value)
        {
            var result = BusinessService.GetOrgMembers(value);
            return result;
        }

        [HttpPost]
        public JsonResult Update([FromBody]OrgShort value)
        {
            var result = BusinessService.Update(value);
            var ret = $"{{\"msg\":\"{result}\"}}";
            return new JsonResult(ret);
            
        }
        [HttpPost]
        public JsonResult Add([FromBody]OrgShort value)
        {
            var result = BusinessService.AddOrg(value);
            var ret = $"{{\"msg\":\"{result}\"}}";
            return new JsonResult(ret);
            
        }

        [HttpPost]
        public JsonResult DeleteOrg([FromBody]OrgShort value)
        {
            var result = BusinessService.DeleteOrg (value);
            var ret = $"{{\"msg\":\"{result}\"}}";
            return new JsonResult(ret);
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
