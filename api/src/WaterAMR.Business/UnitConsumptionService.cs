using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterAMR.Business.Interfaces;
using WaterAMR.Business.Map;
using WaterAMR.BusinessModels;
using WaterAMR.DataAccess.Interfaces;
using WaterAMR.BusinessModels.Realtime;

namespace WaterAMR.Business
{
    public class UnitConsumptionService : IUnitConsumptionService
    {
        private IUnitConsumptionRepository Repository;
        public UnitConsumptionService(IUnitConsumptionRepository repository)
        {
            this.Repository = repository;
            UnitConsumptionServiceMapper.Map();
        }



        public PagedResponse<UnitConsumption> GetUnitConsumption(PagedData<GenericRequest> input, SearchParam searchParam)
        {
            
            var criteria =  Mapper.Map<DataModels.PagedData<DataModels.GenericRequest>>(input);
            var searchparam = Mapper.Map<DataModels.Realtime.SearchParam>(searchParam);
            var data = this.Repository.GetTodayData(criteria, searchparam);
            var result = Mapper.Map<PagedResponse<BusinessModels.Realtime.UnitConsumption>>(data);
            return result;
        }

        public UnitConsumptionSearch GetUnitConsumptionSearch(GenericRequest input)
        {
            var criteria = Mapper.Map<DataModels.GenericRequest>(input);
            var data = this.Repository.GetUnitConsumptionSearch(criteria);
            var result = Mapper.Map<BusinessModels.Realtime.UnitConsumptionSearch>(data);
            return result;
        }

        public UnitConsumptionGraph<string> GetGraph(GenericRequest input, SearchParam criteria)
        {
            var inp = Mapper.Map<DataModels.GenericRequest>(input);
            var searchparam = Mapper.Map<DataModels.Realtime.SearchParam>(criteria);
            var data = this.Repository.GetGraph (inp, searchparam);
            var result = Mapper.Map<UnitConsumptionGraph<string>>(data);
            return result;
        }

        public PagedResponse<UnitConsumptionHistory> GetHistoryforUnit(PagedData<UnitConsumptionHistoryInput> input)
        {
            var inp = Mapper.Map<DataModels.PagedData<DataModels.Realtime.UnitConsumptionHistoryInput>>(input);
            var data = this.Repository.GetHistoryforUnit(inp);
            var result = Mapper.Map<PagedResponse<BusinessModels.Realtime.UnitConsumptionHistory>>(data);
            return result;
        }

        public UnitConsumptionGraph<DateTime> GetHistoryGraph(UnitConsumptionHistoryInput input)
        {
            var inp = Mapper.Map<DataModels.Realtime.UnitConsumptionHistoryInput>(input);
            var data = this.Repository.GetHistoryGraph(inp);
            var result = Mapper.Map<UnitConsumptionGraph<DateTime>>(data);
            return result;
        }
        public PagedResponse<BusinessModels.UnitSummary.MessageRejected> GetRejectedMessages(PagedData<BusinessModels.UnitSummary.MessageRejectedInput> input)
        {
            var result = this.Repository.GetRejectedMessages(Mapper.Map<DataModels.PagedData<DataModels.UnitSummary.MessageRejectedInput>>(input));
            return Mapper.Map<PagedResponse<BusinessModels.UnitSummary.MessageRejected>>(result);
        }
    }
}
