using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WaterAMR.BusinessModels;
using WaterAMR.BusinessModels.Realtime;
using Newtonsoft.Json;
using WaterAMR.Business.Interfaces;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WaterAMR.API.Controllers.RealTime
{
    [Route("api/[controller]")]
    public class UnitConsumptionGraphController : Controller
    {
        private IUnitConsumptionService businessService = null;
        public UnitConsumptionGraphController(IUnitConsumptionService businessServiceObj)
        {
            this.businessService = businessServiceObj;
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
        public UnitConsumptionGraph<string> Post([FromBody] GenericRequest input )
        {
            SearchParam searchParam = null;
            if (!string.IsNullOrEmpty(input.Criteria))
                searchParam = JsonConvert.DeserializeObject<SearchParam>(input.Criteria);
            return this.businessService.GetGraph(input, searchParam);
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
