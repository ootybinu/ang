using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterAMR.DataModels;
using WaterAMR.DataModels.Realtime;

namespace WaterAMR.DataAccess.Interfaces
{
    public interface IUnitConsumptionRepository
    {
        PagedResponse<UnitConsumption> GetTodayData(PagedData<GenericRequest> input, SearchParam searchParam);
        UnitConsumptionSearch GetUnitConsumptionSearch(GenericRequest input);
        UnitConsumptionGraph<string> GetGraph(GenericRequest input, SearchParam criteria);
        PagedResponse<UnitConsumptionHistory> GetHistoryforUnit(PagedData<UnitConsumptionHistoryInput> input);
        UnitConsumptionGraph<DateTime> GetHistoryGraph(UnitConsumptionHistoryInput input);
        PagedResponse<DataModels.UnitSummary.MessageRejected> GetRejectedMessages(PagedData<DataModels.UnitSummary.MessageRejectedInput> input);
    }
}
