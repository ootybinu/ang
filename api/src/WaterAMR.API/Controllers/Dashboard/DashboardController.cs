using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WaterAMR.Business.Interfaces;
using WaterAMR.BusinessModels.Dashboard;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WaterAMR.API.Controllers.Dashboard
{
    [Route("api/[controller]/[action]")]
    public class DashboardController : Controller
    {
        private IDashboardService BusinessService; 
        public DashboardController(IDashboardService service)
        {
            BusinessService = service;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var value = new ConsumptionInput();
            var result = BusinessService.GetMessageData(value);
            //return result;
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            //var result = BusinessService.GetConsumptionData(id);
            //var r = new JsonResult(result);
            //return r;

            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        [HttpPost]
        public JsonResult GetConsumptionData([FromBody]ConsumptionInput value)
        {
            var result = BusinessService.GetConsumptionData(value);
            var r = new JsonResult(result);
            return r;
        }

        [HttpPost]
        public JsonResult GetDivisionWise([FromBody]ConsumptionInput value)
        {
            var result = BusinessService.GetDivisionWise(value);
            var r = new JsonResult(result);
            return r;
        }

        [HttpPost]
        public JsonResult GetOemWise([FromBody]ConsumptionInput value)
        {
            var result = BusinessService.GetOemWise(value);
            var r = new JsonResult(result);
            return r;
        }

        [HttpPost]
        public List<KeyValuePair<string, string>> GetMessageData([FromBody]ConsumptionInput value)
        {
            var result = BusinessService.GetMessageData(value);
            return result;
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
