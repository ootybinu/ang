using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WaterAMR.Business.Interfaces;
using WaterAMR.BusinessModels;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WaterAMR.API.Controllers.Oem
{
    [Route("api/[controller]/[action]")]
    public class OemController : Controller
    {
        private IOemService BusinessService;
        public OemController(IOemService service)
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
        public PagedResponse<BusinessModels.Oem.Oem> GetAll([FromBody]PagedData<BusinessModels.Oem.OemInput> value)
        {
            return BusinessService.GetAll(value);
        }

        [HttpPost]
        public string Save([FromBody]BusinessModels.Oem.Oem value)
        {
            var result = BusinessService.Save(value);
            return "{\"result\":\"" + result + "\"}";
        }

        [HttpPost]
        public IEnumerable<BusinessModels.Oem.oemeffiency> GetOemEffiency()
        {
            return BusinessService.GetOemEffiency();
        }

        [HttpPost]
        public IEnumerable<BusinessModels.Oem.oemefficiencydetail> GetOemEfficiencyDetail([FromBody] string oemCode)
        {
            return BusinessService.GetOemEfficiencyDetail(oemCode);
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
