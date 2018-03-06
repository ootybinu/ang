using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterAMR.Business.Interfaces;
using WaterAMR.Business.Map;
using WaterAMR.BusinessModels;
using WaterAMR.BusinessModels.UnitReport;
using WaterAMR.DataAccess.Interfaces;

namespace WaterAMR.Business
{
    public class UnitReportService : IUnitReportService
    {
        private IUnitReportRepository Repository;
        public UnitReportService(IUnitReportRepository repository)
        {
            this.Repository = repository;
            UnitReportServiceMapper.Map();
        }
        public Search GetInitialSearchLists(GenericRequest request)
        {
            var req = Mapper.Map<DataModels.GenericRequest>(request);
            var data = Repository.GetInitialSearchLists(req);
            var result = Mapper.Map<BusinessModels.UnitReport.Search>(data);
            return result;
        }

        public IEnumerable<KeyValuePair<Int32, string>> GetSubList(Int32 parentid, Int32 typeId)
        {
            var data = Repository.GetSubList(parentid, typeId);
            var result = Mapper.Map<IEnumerable< KeyValuePair<Int32,string>>>(data);
            return result;
        }

        public PagedResponse<UnitReport> GetUnitReport(PagedData<SearchCriteria> criteria)
        {
            var req = Mapper.Map<DataModels.PagedData< DataModels.UnitReport.SearchCriteria>>(criteria);
            var data = Repository.GetUnitReport(req);
            var result = Mapper.Map<BusinessModels.PagedResponse<BusinessModels.UnitReport.UnitReport>>(data);
            return result;
        }
    }
}
