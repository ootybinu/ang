using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterAMR.DataModels.GPRSdata;

namespace WaterAMR.DataAccess.Interfaces
{
    public interface IGPRSdataRepository
    {
        IEnumerable<GprsData> GetGprsData(string onDate);
        IEnumerable<GprsDetail> GetGprsHistory(string id);
        IEnumerable<GprsDetail> GetGprsDetail(string id, string ondate);
    }
}
