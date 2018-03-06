using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterAMR.BusinessModels;
using WaterAMR.BusinessModels.TamperDetection;

namespace WaterAMR.Business.Interfaces
{
    public interface ITamperDetectionService
    {
        PagedResponse<TamperData> GetData(PagedData<TamperCriteria> criteria);
        IEnumerable<KeyValuePair<string, string>> GetUnitList(string location);

    }
}
