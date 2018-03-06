using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WaterAMR.Business.Interfaces;
using WaterAMR.BusinessModels.Billing;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WaterAMR.API.Controllers
{
    [Route("api/[controller]/[action]")]
    public class CommonController : Controller
    {
        private ICommonService BusinessService;
        public CommonController(ICommonService service )
        {
            BusinessService = service;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            //BusinessService.Add();

            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        //[Route("api/[controller]/Master")]
        //[HttpPost]
        //public IEnumerable<KeyValuePair<string,string>> Post([FromBody]string value)
        //{
        //    return BusinessService.GetMasterValues(value);
        //}

        //[Route("api/CommonController/OrganizationList")]
        //[Route("OrganizationList/{value}")]
        [HttpPost]
        public IEnumerable<KeyValuePair<int, string>> GetPlaceList([FromBody]PlaceListInput input)
        {
            var result = BusinessService.GetPlaceList(input.ParentId, input.TypeId);
            return result;
        }
        [HttpPost]
        public IEnumerable<KeyValuePair<string, string>> GetMasterValues([FromBody]string input)
        {
            var result = BusinessService.GetMasterValues(input);
            return result;
        }
        [HttpPost()] 
        public IEnumerable<KeyValuePair<Int32, string>> OrganizationList([FromBody]string value)
        {
            var orgtypeid = string.IsNullOrEmpty(value) ? 1 : Convert.ToInt32(value);
            return BusinessService.GetFromOrganization(orgtypeid);
        }
        [HttpPost()]
        public IEnumerable<KeyValuePair<Int32, string>> GetBillingGroups()
        {
            return BusinessService.GetBillingGroups();
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
