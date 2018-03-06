using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WaterAMR.Business.Interfaces;
using WaterAMR.BusinessModels;
using WaterAMR.BusinessModels.Realtime;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WaterAMR.API.Controllers.RealTime
{
    [Route("api/[controller]")]
    public class UnitConsumptionSearchController : Controller
    {
        public UnitConsumptionSearchController(IUnitConsumptionService businessServiceObj)
        {
            this.businessService = businessServiceObj;
        }
        private IUnitConsumptionService businessService = null;
        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value3", "value4" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public UnitConsumptionSearch Post([FromBody]GenericRequest value)
        {
            return this.businessService.GetUnitConsumptionSearch(value);
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
