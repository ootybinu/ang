using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WaterAMR.Business.Interfaces;
using WaterAMR.BusinessModels.Security;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WaterAMR.API.Controllers.Security
{
    [Route("api/[controller]")]
    public class SecurityController : Controller
    {
        private ISecurityService BusinessService; 
        public SecurityController(ISecurityService service)
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
        public AuthenticationResult Post([FromBody] Object user)
        {
            dynamic input = user;
            string username = input.username.Value;
            string password = input.password.Value;
            var pwd = Utility.Security.EncrptPassword(username.ToLower()+ password);
            string ipAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            
            string browserName = Request.Headers["User-Agent"].ToString();
            return this.BusinessService.Authenticate(username, pwd, ipAddress, browserName);

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
