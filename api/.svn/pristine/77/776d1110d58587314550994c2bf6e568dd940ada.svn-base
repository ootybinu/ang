using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WaterAMR.Business.Interfaces;
using WaterAMR.BusinessModels.Organization;
using WaterAMR.BusinessModels;
using WaterAMR.BusinessModels.TamperDetection;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WaterAMR.API.Controllers.TamperDetection
{
    [Route("api/[controller]/[action]")]
    public class TamperDetectionController : Controller
    {
        ITamperDetectionService businessService;
        IOrganizationService orgService;
        public TamperDetectionController(ITamperDetectionService service, IOrganizationService orgservice)
        {
            businessService = service;
            orgService = orgservice;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpPost]
        public IEnumerable<OrgShort> GetList([FromBody]OrgInput value)
        {
            var result = orgService.GetOrgMembers(value);
            return result;
        }

        [HttpPost]
        public IEnumerable<KeyValuePair<string,string>> GetUnitList([FromBody]OrgInput value)
        {
            var result = businessService.GetUnitList(value.parentid.ToString());

            return result;
        }
        [HttpPost]
        public PagedResponse<TamperData> GetData([FromBody] PagedData<TamperCriteria> criteria)
        {
            var result = businessService.GetData(criteria);
            return result;
        }
        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
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
