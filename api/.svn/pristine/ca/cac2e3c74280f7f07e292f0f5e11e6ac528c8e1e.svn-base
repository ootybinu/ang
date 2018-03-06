using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WaterAMR.Business.Interfaces;
using WaterAMR.BusinessModels.Payment;
using WaterAMR.BusinessModels;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WaterAMR.API.Controllers.Payment
{
    [Route("api/[controller]/[action]")]
    public class PaymentController : Controller
    {
        private IPaymentService Service; 
        public PaymentController( IPaymentService service)
        {
            Service = service;
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
        // POST api/values
        [HttpPost]
        public JsonResult AddPayment([FromBody]PaymentDetail detail)
        {
            var result = this.Service.AddPayment(detail);
            var ret = $"{{\"msg\":\"{result}\"}}";
            return new JsonResult(ret);
        }
        [HttpPost]
        public PaymentResultVM GetPaymentDetails([FromBody]long  BillNo)
        {
            var result = this.Service.GetPayments(BillNo);
            return result;
        }
        [HttpPost]
        public PaymentAuthenticationVM GetAuthenticationData([FromBody]string date)
        {
            var result = this.Service.GetAuthenticationData(date);
            return result;
        }
        [HttpPost]
        public JsonResult CancelPayment([FromBody]long PaymentId)
        {
            var result = this.Service.CancelPayment(PaymentId);
            var ret = $"{{\"msg\":\"{result}\"}}";
            return new JsonResult(ret);
        }

        [HttpPost]
        public JsonResult Authenticate([FromBody]string date)
        {
            var result = this.Service.Authenticate(date);
            var ret = $"{{\"msg\":\"{result}\"}}";
            return new JsonResult(ret);
        }
        [HttpPost]
        public PagedResponse<PaymentProcess> Process([FromBody] PagedData<ProcessInput> input)
        {
            var result = this.Service.Process(input);
            return result;
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
