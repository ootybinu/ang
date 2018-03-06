using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterAMR.BusinessModels;
using WaterAMR.BusinessModels.Billing;

namespace WaterAMR.Business.Interfaces
{
    public interface IBillingService
    {
        string GenerateBill(BillGenerateInput input);
        PagedResponse<BillDetail> GetBills(PagedData<BillFilter> input);
        //BillGroupResult Validate(BillGenerateInput input);
        PagedResponse<BillGroupDetailVM> GetBillGroupDetails(PagedData<BillGenerateInput> input);
        PagedResponse<BillGroup> GetBillGroupMaster(PagedData<BGInput> input);
        string UpdateBillGroupMaster(BillGroup input);
        string DeleteBillGroupMaster(BillGroup input);
        List<KeyValuePair<long, string>> GetBillGroupList(BillGenerateInput input);
        BillGroupDetailVM GetBillGroup(long billgroupId);
        string GenerateBillBGWise(long BillGroupDetailId);
        //string AddBillGroupDetail(BillGenerateInput input);
        PagedResponse<BillDetail> GetBillsforPrint(PagedData<BillGenerateInput> pagedInput);
        BillDetail GetBill(int BillNo);
        string UpdateBillGroupItem(BillGroupDetail input);
    }
}
