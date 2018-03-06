using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterAMR.Business.Interfaces;
using WaterAMR.Business.Map;
using WaterAMR.BusinessModels;
using WaterAMR.BusinessModels.Billing;
using WaterAMR.DataAccess.Interfaces;


namespace WaterAMR.Business
{
    public class BillingService:IBillingService
    {
        private IBillingRepository Repository;
        
        public BillingService(IBillingRepository repos)
        {
            Repository = repos;
            
            BillingMapper.Map();
        }
        public string GenerateBill(BillGenerateInput input)
        {
            var req = Mapper.Map<DataModels.Billing.BillGenerateInput>(input);
            return Repository.GenerateBill(req);
        }
        public PagedResponse<BillDetail> GetBills(PagedData<BillFilter> input)
        {
            var req = Mapper.Map<DataModels.PagedData<DataModels.Billing.BillFilter>>(input);
            var data = Repository.GetBills(req);
            var result = Mapper.Map<BusinessModels.PagedResponse<BusinessModels.Billing.BillDetail>>(data);
            return result;
        }
        public BillGroupDetailVM GetBillGroup(long billgroupId)
        {
            return Mapper.Map<BusinessModels.Billing.BillGroupDetailVM>(Repository.GetBillGroup(billgroupId));
        }
        public string GenerateBillBGWise(long BillGroupDetailId) {
            return Repository.GenerateBillBGWise(BillGroupDetailId);
        }
        //public BillGroupResult Validate(BillGenerateInput input)
        //{
        //    var result = Repository.Validate(Mapper.Map<DataModels.Billing.BillGenerateInput>(input));
        //    return Mapper.Map<BusinessModels.Billing.BillGroupResult>(result);
        //}
        public PagedResponse<BillGroupDetailVM> GetBillGroupDetails(PagedData<BillGenerateInput> input)
        {
            var result = Repository.GetBillGroupDetails(Mapper.Map<DataModels.PagedData< DataModels.Billing.BillGenerateInput>>(input));
            return Mapper.Map<PagedResponse<BusinessModels.Billing.BillGroupDetailVM>>(result);
        }
        public PagedResponse<BillGroup> GetBillGroupMaster(PagedData<BusinessModels.Billing. BGInput> input) {
            var result = Repository.GetBillGroupMaster(Mapper.Map<DataModels.PagedData<DataModels.Billing.BGInput>>(input));
            return Mapper.Map<PagedResponse<BusinessModels.Billing.BillGroup>>(result);

        }
        public string UpdateBillGroupMaster(BillGroup input) {
            return Repository.UpdateBillGroupMaster(Mapper.Map<DataModels.Billing.BillGroup>(input));
        }
        public string DeleteBillGroupMaster(BillGroup input) {
            return Repository.DeleteBillGroupMaster (Mapper.Map<DataModels.Billing.BillGroup>(input));
        }
        public List<KeyValuePair<long, string>> GetBillGroupList(BillGenerateInput input) {
            return Repository.GetBillGroupList(Mapper.Map<DataModels.Billing.BillGenerateInput>(input));

        }
        public PagedResponse<BillDetail> GetBillsforPrint(PagedData<BillGenerateInput> pagedInput)
        {
            var result = Repository.GetBillsforPrint(Mapper.Map<DataModels.PagedData<DataModels.Billing.BillGenerateInput>>(pagedInput));
            return Mapper.Map<PagedResponse<BusinessModels.Billing.BillDetail>>(result);
        }
        public BillDetail GetBill(int BillNo)
        {
            return Mapper.Map<BusinessModels.Billing.BillDetail>(Repository.GetBill(BillNo));
            
        }
        public string UpdateBillGroupItem(BillGroupDetail input)
        {
            return Repository.UpdateBillGroupItem(Mapper.Map<DataModels.Billing.BillGroupDetail>(input));
        }
        //public string AddBillGroupDetail(BillGenerateInput input) {
        //    return Repository.AddBillGroupDetail(Mapper.Map<DataModels.Billing.BillGenerateInput>(input));
        //}
    }
}
