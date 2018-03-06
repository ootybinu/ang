using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WaterAMR.Business.Interfaces;
using WaterAMR.BusinessModels;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WaterAMR.API.Controllers.Tariff
{
    [Route("api/[controller]/[action]")]
    public class TariffController : Controller
    {
        private ITariffService service;
        public TariffController(ITariffService servic)
        {
            service = servic;
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
        public JsonResult Generate([FromBody]BusinessModels.Tariff.TariffInput input)
        {
            var result = service.Generate(input);
            var ret = $"{{\"msg\":\"{result}\"}}";
            return new JsonResult(ret);
        }

        [HttpPost]
        public PagedResponse<BusinessModels.Tariff.TariffMasterFull> GetTariffConfig([FromBody]PagedData<BusinessModels.Tariff.TariffInput> input)
        {
            var result = service.GetTariffConfig(input);
            return result;
        }

        [HttpPost]
        public JsonResult Update([FromBody]BusinessModels.Billing.TariffMaster input)
        {
            var result = service.Update(input);
            var ret = $"{{\"msg\":\"{result}\"}}";
            return new JsonResult(ret);
        }
        [HttpPost]
        public JsonResult Delete([FromBody]BusinessModels.Billing.TariffMaster input)
        {
            var result = service.Delete(input);
            var ret = $"{{\"msg\":\"{result}\"}}";
            return new JsonResult(ret);
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
