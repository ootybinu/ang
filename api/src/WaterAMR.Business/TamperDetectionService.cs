using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterAMR.Business.Interfaces;
using WaterAMR.Business.Map;
using WaterAMR.BusinessModels;
using WaterAMR.BusinessModels.TamperDetection;
using WaterAMR.DataAccess.Interfaces;

namespace WaterAMR.Business
{
    public class TamperDetectionService : ITamperDetectionService
    {
        private ITamperDetectionRepository Repository;
        public TamperDetectionService(ITamperDetectionRepository repos)
        {
            Repository = repos;
            TamperDetectionMapper.Map();
        }
        public PagedResponse<TamperData> GetData(PagedData<TamperCriteria> criteria)
        {
            TamperDetectionMapper.Map();
            var inp = Mapper.Map<DataModels.PagedData<DataModels.TamperDetection.TamperCriteria>>(criteria);
            var result = Repository.GetData(inp);
            return Mapper.Map<BusinessModels.PagedResponse<BusinessModels.TamperDetection.TamperData>>(result);
        }

        public IEnumerable<KeyValuePair<string, string>> GetUnitList(string location)
        {
            return Repository.GetUnitList(location);
        }
    }
}
