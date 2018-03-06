using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterAMR.Business.Interfaces;
using WaterAMR.Business.Map;
using WaterAMR.BusinessModels.UnitSummary;
using WaterAMR.DataAccess.Interfaces;
using WaterAMR.BusinessModels;

namespace WaterAMR.Business
{
    public class UnitSummaryService : IUnitSummaryService
    {
        private IUnitSummaryRepository Repository;
        public UnitSummaryService(IUnitSummaryRepository repos)
        {
            Repository = repos;
            UnitSummaryMapper.Map();
        }

        public UnitSummaySelectionLists GetInitialLists()
        {
            var result1 = Repository.GetInitialLists();
            var result =Mapper.Map<BusinessModels.UnitSummary.UnitSummaySelectionLists>(result1);
            return result;
        }
        public PagedResponse<UnitSummaryRow> GetAll(PagedData<SearchParam> input)
        {
            var inp = Mapper.Map<DataModels.PagedData<DataModels.UnitSummary.SearchParam>>(input);
            var result = Repository.GetAll(inp);
            return Mapper.Map<BusinessModels.PagedResponse<BusinessModels.UnitSummary.UnitSummaryRow>>(result);

        }

        public UnitSummaryResult GetDetail(string id)
        {
            var result = Repository.GetDetail(id);
            return Mapper.Map<BusinessModels.UnitSummary.UnitSummaryResult>(result);

        }

        public bool UpdateUnit(UnitSummary unitSummary)
        {
            return Repository.UpdateUnit(Mapper.Map<DataModels.UnitSummary.UnitSummary>(unitSummary));
        }
    }
}
