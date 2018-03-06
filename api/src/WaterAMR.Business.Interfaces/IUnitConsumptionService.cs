using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterAMR.BusinessModels;
using WaterAMR.BusinessModels.Realtime;

namespace WaterAMR.Business.Interfaces
{
    public interface IUnitConsumptionService
    {
        PagedResponse<UnitConsumption> GetUnitConsumption(PagedData<GenericRequest> input, SearchParam searchParam);
        UnitConsumptionSearch GetUnitConsumptionSearch(GenericRequest input);
        UnitConsumptionGraph<string> GetGraph(GenericRequest input, SearchParam criteria);
        PagedResponse<UnitConsumptionHistory> GetHistoryforUnit(PagedData<UnitConsumptionHistoryInput> input);
        UnitConsumptionGraph<DateTime> GetHistoryGraph(UnitConsumptionHistoryInput input);
        PagedResponse<BusinessModels.UnitSummary.MessageRejected> GetRejectedMessages(PagedData<BusinessModels.UnitSummary.MessageRejectedInput> input);
    }
}
