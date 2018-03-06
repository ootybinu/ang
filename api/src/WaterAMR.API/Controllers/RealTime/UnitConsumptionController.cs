using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WaterAMR.BusinessModels;
using WaterAMR.Business.Interfaces;
using WaterAMR.BusinessModels.Realtime;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WaterAMR.API.Controllers.RealTime
{
    [Route("api/[controller]/[action]")]
    public class UnitConsumptionController : Controller
    {
        private IUnitConsumptionService businessService = null;
        public UnitConsumptionController(IUnitConsumptionService businessServiceObj)
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
        [HttpPost]
        public PagedResponse<UnitConsumption> GetConsumptionData([FromBody] PagedData<GenericRequest> criteria)
        {
            SearchParam searchParam = null;
            if (!string.IsNullOrEmpty( criteria.Data.Criteria))
                searchParam =  JsonConvert.DeserializeObject<SearchParam>(criteria.Data.Criteria);
            return this.businessService.GetUnitConsumption(criteria, searchParam);
        }
        [HttpPost]
        public PagedResponse<BusinessModels.UnitSummary.MessageRejected> GetRejectedMessages([FromBody] PagedData<BusinessModels.UnitSummary.MessageRejectedInput> input)
        {
            return this.businessService.GetRejectedMessages(input);
        }
        //// POST api/values
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
