using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterAMR.BusinessModels;
using WaterAMR.BusinessModels.UnitReport;

namespace WaterAMR.Business.Interfaces
{
    public interface IUnitReportService
    {
        Search GetInitialSearchLists(GenericRequest request);
        IEnumerable<KeyValuePair<Int32, string>> GetSubList(Int32 parentid, Int32 typeId);
        PagedResponse<UnitReport> GetUnitReport(PagedData<SearchCriteria> criteria);
    }
}
