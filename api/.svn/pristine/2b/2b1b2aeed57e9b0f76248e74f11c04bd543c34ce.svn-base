using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterAMR.DataModels;
using WaterAMR.DataModels.UnitSummary;

namespace WaterAMR.DataAccess.Interfaces
{
    public interface IUnitSummaryRepository
    {
        UnitSummaySelectionLists GetInitialLists();
        PagedResponse<UnitSummaryRow> GetAll(PagedData<SearchParam> input);
        UnitSummaryResult GetDetail(string id);
        bool UpdateUnit(UnitSummary unitSummary);

    }
}
