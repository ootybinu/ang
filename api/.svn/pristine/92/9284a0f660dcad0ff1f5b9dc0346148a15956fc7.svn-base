using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WaterAMR.Business.Interfaces;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WaterAMR.API.Controllers.UnitReport
{
    [Route("api/[controller]")]
    public class UnitReportSearchSubItemController : Controller
    {
        private IUnitReportService businessService;
        public UnitReportSearchSubItemController(IUnitReportService service)
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
        public IEnumerable<KeyValuePair<Int32, string>> Post([FromBody]Object input)
        {
            dynamic json = input;
            var parentId = Convert.ToInt32(json.parentId.Value);
            var typeId = Convert.ToInt32(json.typeId.Value);
            return this.businessService.GetSubList(parentId, typeId);
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
