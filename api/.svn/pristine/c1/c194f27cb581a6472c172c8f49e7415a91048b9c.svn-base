using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterAMR.BusinessModels;
using WaterAMR.BusinessModels.UnitSummary;

namespace WaterAMR.Business.Interfaces
{
    public interface IUnitSummaryService
    {
        UnitSummaySelectionLists GetInitialLists();
        PagedResponse<UnitSummaryRow> GetAll(PagedData<SearchParam> input);
        UnitSummaryResult GetDetail(string id);
        bool UpdateUnit(UnitSummary unitSummary);
    }
}
