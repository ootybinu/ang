using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterAMR.BusinessModels.GPRSdata;

namespace WaterAMR.Business.Interfaces
{
    public interface IGPRSdataService
    {
        IEnumerable<GprsData> GetGprsData(string onDate);
        IEnumerable<GprsDetail> GetGprsHistory(string id);
        IEnumerable<GprsDetail> GetGprsDetail(string id, string ondate);
    }
}
