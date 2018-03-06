using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterAMR.DataModels;
using WaterAMR.DataModels.UnitReport;

namespace WaterAMR.DataAccess.Interfaces
{
    public interface IUnitReportRepository
    {
        Search GetInitialSearchLists(GenericRequest request);
        IEnumerable<db_KeyValuePair> GetSubList(Int32 parentId, Int32 typeId);
        PagedResponse<UnitReport> GetUnitReport(PagedData<SearchCriteria> criteria);
    }
}
