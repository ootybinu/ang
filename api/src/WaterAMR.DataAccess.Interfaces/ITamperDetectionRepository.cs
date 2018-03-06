using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterAMR.DataModels;
using WaterAMR.DataModels.TamperDetection;

namespace WaterAMR.DataAccess.Interfaces
{
    public interface ITamperDetectionRepository
    {
        PagedResponse<TamperData> GetData(PagedData<TamperCriteria> criteria);
        IEnumerable<KeyValuePair<string, string>> GetUnitList(string location);
    }
}
