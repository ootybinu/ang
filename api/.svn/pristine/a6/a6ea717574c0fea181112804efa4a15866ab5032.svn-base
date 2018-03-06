using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WaterAMR.Business.Interfaces;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WaterAMR.API.Controllers.GPRSdata
{
    [Route("api/[controller]")]
    public class GPRSdetailController : Controller
    {
        private IGPRSdataService BusinessService;
        public GPRSdetailController(IGPRSdataService service)
        {
            this.BusinessService = service;
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
        public IEnumerable<BusinessModels.GPRSdata.GprsDetail> Post([FromBody]Object value)
        {
            dynamic obj = value;
            string id = obj.id.Value;
            string ondate = obj.ondate.Value;
            return this.BusinessService.GetGprsDetail(id, ondate);
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
