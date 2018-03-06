using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WaterAMR.Business.Interfaces;
using WaterAMR.BusinessModels.Billing;
using WaterAMR.BusinessModels;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WaterAMR.API.Controllers.Billing
{
    [Route("api/[controller]/[action]")]
    public class BillController : Controller
    {
        private IBillingService BusinessService;
        public BillController(IBillingService service)
        {
            BusinessService = service;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            //var result = BusinessService.GenerateBill("032016", "1");
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
        public JsonResult  Generate([FromBody]BillGenerateInput input)
        {
            var result = BusinessService.GenerateBill(input);
            
            var ret = $"{{\"msg\":\"{result}\"}}";
            return new JsonResult(ret);
        }

        [HttpPost]
        public JsonResult GenerateBillBGWise([FromBody]long BillGroupDetailId)
        {
            var result = BusinessService.GenerateBillBGWise(BillGroupDetailId);
            var ret = $"{{\"msg\":\"{result}\"}}";
            return new JsonResult(ret);
        }
        [HttpPost]
        public JsonResult UpdateBillGroupMaster([FromBody]BillGroup input)
        {
            var result = BusinessService.UpdateBillGroupMaster(input);

            var ret = $"{{\"msg\":\"{result}\"}}";
            return new JsonResult(ret);
        }
        [HttpPost]
        public JsonResult DeleteBillGroupMaster([FromBody]BillGroup input)
        {
            var result = BusinessService.DeleteBillGroupMaster(input);

            var ret = $"{{\"msg\":\"{result}\"}}";
            return new JsonResult(ret);
        }
        [HttpPost]
        public JsonResult UpdateBillGroupItem([FromBody]BillGroupDetail input)
        {
            var result = BusinessService.UpdateBillGroupItem(input);

            var ret = $"{{\"msg\":\"{result}\"}}";
            return new JsonResult(ret);
        }
        //[HttpPost]
        //public JsonResult AddBillGroupDetail([FromBody]BillGenerateInput input)
        //{
        //    var result = BusinessService.AddBillGroupDetail(input);

        //    var ret = $"{{\"msg\":\"{result}\"}}";
        //    return new JsonResult(ret);
        //}

        [HttpPost]
        public BillGroupDetailVM GetBillGroup([FromBody]long billgroupId)
        {
            return BusinessService.GetBillGroup(billgroupId);
        }
        [HttpPost]
        public List<KeyValuePair<long, string>> GetBillGroupList([FromBody]BillGenerateInput input)
        {
            var result = BusinessService.GetBillGroupList(input);
            return result;
        }


        [HttpPost]
        public PagedResponse<BillGroupDetailVM> GetBillGroupDetails([FromBody] PagedData<BillGenerateInput> req)
        {
            var result = BusinessService.GetBillGroupDetails(req);
            return result;
        }
        [HttpPost]
        public PagedResponse<BillGroup> GetBillGroupMaster([FromBody] PagedData<BGInput> req)
        {
            var result = BusinessService.GetBillGroupMaster(req);
            return result;
        }
        [HttpPost]
        public PagedResponse<BillDetail> GetBills([FromBody] PagedData<BillFilter> req)
        {
            var result = BusinessService.GetBills(req);
            return result;
        }
        [HttpPost]
        public BillDetail GetBill([FromBody] int billNumber)
        {
            var result = BusinessService.GetBill (billNumber);
            return result;
        }
        [HttpPost]
        public PagedResponse<BillDetail> GetBillsForPrint([FromBody] PagedData<BillGenerateInput> req)
        {
            var result = BusinessService.GetBillsforPrint(req);
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
