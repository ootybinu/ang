using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterAMR.BusinessModels;
using WaterAMR.BusinessModels.Revenue;

namespace WaterAMR.Business.Interfaces
{
    public interface IRevenueService
    {
        PagedResponse<Revenue> GetRevenueList(PagedData<RevenueInput> input);
    }
}
