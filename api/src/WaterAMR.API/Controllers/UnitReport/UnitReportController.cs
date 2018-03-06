using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WaterAMR.Business.Interfaces;
using WaterAMR.BusinessModels.UnitReport;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WaterAMR.API.Controllers.UnitReport
{
    [Route("api/[controller]")]
    public class UnitReportController : Controller
    {
        private IUnitReportService businessService;
        public UnitReportController(IUnitReportService service)
        {
            this.businessService = service;
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
        public BusinessModels.PagedResponse<BusinessModels.UnitReport.UnitReport> Post([FromBody]BusinessModels.PagedData<SearchCriteria> value)
        {
            return this.businessService.GetUnitReport(value);
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
