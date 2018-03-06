using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WaterAMR.Business.Interfaces;
using WaterAMR.BusinessModels.UnitSummary;
using WaterAMR.BusinessModels;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WaterAMR.API.Controllers.UnitSummary
{
    [Route("api/[controller]/[action]")]
    public class UnitSummaryController : Controller
    {
        private IUnitSummaryService BusinessService;
        public UnitSummaryController(IUnitSummaryService service)
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
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        [HttpPost]
        public PagedResponse<BusinessModels.UnitSummary.UnitSummaryRow> GetAll([FromBody]PagedData<BusinessModels.UnitSummary.SearchParam> value)
        {
            return BusinessService.GetAll(value);
        }
        [HttpPost]
        public UnitSummaySelectionLists GetInitialLists()
        {
            return BusinessService.GetInitialLists();
        }

        [HttpPost]
        public BusinessModels.UnitSummary.UnitSummaryResult GetDetail([FromBody]string value)
        {
            return BusinessService.GetDetail(value);
        }

        [HttpPost]
        public bool UpdateUnit([FromBody]BusinessModels.UnitSummary.UnitSummary unitSummary)
        {
            return BusinessService.UpdateUnit (unitSummary);
        }

        [HttpPost]
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
