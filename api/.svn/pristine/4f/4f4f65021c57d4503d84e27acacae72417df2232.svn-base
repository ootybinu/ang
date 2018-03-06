using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterAMR.Business.Interfaces;
using WaterAMR.Business.Map;
using WaterAMR.BusinessModels;
using WaterAMR.BusinessModels.Revenue;
using WaterAMR.DataAccess.Interfaces;

namespace WaterAMR.Business
{
    public class RevenueService : IRevenueService
    {
        private IRevenueRepository Repository;
        public RevenueService(IRevenueRepository repos)
        {
            Repository = repos;
            RevenueMapper.Map();
        }

        public PagedResponse<Revenue> GetRevenueList(PagedData<RevenueInput> input)
        {
            var inputParam = Mapper.Map<DataModels.PagedData< DataModels.Revenue.RevenueInput>>(input);
            return Mapper.Map<PagedResponse<BusinessModels.Revenue.Revenue>>(Repository.GetRevenueList(inputParam));
        }
    }
}
