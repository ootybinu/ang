using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WaterAMR.Business.Interfaces;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WaterAMR.API.Controllers.User
{
    [Route("api/[controller]")]
    public class UpdateUserPasswordController : Controller
    {
                private IUserService BusinessService;
        public UpdateUserPasswordController(IUserService service)
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

       // [Route("UpdatePassword/{kv}")]
        [HttpPost]
        public bool Post([FromBody]KeyValuePair<string, string> kv)
        {
            var pwd = Utility.Security.EncrptPassword(kv.Key.ToLower() + kv.Value);
            return BusinessService.UpdatePassword(kv.Key, pwd);

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
