using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterAMR.DataModels;
using WaterAMR.DataModels.Revenue;

namespace WaterAMR.DataAccess.Interfaces
{
    public interface IRevenueRepository
    {
        PagedResponse<Revenue> GetRevenueList(PagedData<RevenueInput> input);
    }
}
