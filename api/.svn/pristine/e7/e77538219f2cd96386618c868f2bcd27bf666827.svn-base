using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterAMR.DataModels;
using WaterAMR.DataModels.Billing;

namespace WaterAMR.DataAccess.Interfaces
{
    public interface IBillingRepository
    {
        string GenerateBill(BillGenerateInput input);
        PagedResponse<BillDetail> GetBills(PagedData<BillFilter> input);
        PagedResponse<BillGroup> GetBillGroupMaster(PagedData<BGInput> input);
        //BillGroupResult Validate(BillGenerateInput input);
        PagedResponse<BillGroupDetailVM> GetBillGroupDetails(PagedData<BillGenerateInput> input);
        string UpdateBillGroupMaster(BillGroup input);
        string DeleteBillGroupMaster(BillGroup input);
        List<KeyValuePair<long, string>> GetBillGroupList(BillGenerateInput input);
        BillGroupDetailVM GetBillGroup(long billgroupId);
        string GenerateBillBGWise(long BillGroupDetailId);
        PagedResponse<BillDetail> GetBillsforPrint(PagedData<BillGenerateInput> pagedInput);
        BillDetail GetBill(int BillNo);
        string UpdateBillGroupItem(BillGroupDetail input);
        //string AddBillGroupDetail(BillGenerateInput input);
    }
}
