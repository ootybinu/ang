using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterAMR.DataModels;
using WaterAMR.DataModels.Oem;

namespace WaterAMR.DataAccess.Interfaces
{
    public interface IOemRepository
    {
        PagedResponse<Oem> GetAll(PagedData<OemInput> input);
        string Save(Oem input);
        IEnumerable<oemeffiency> GetOemEffiency();
        IEnumerable<oemefficiencydetail> GetOemEfficiencyDetail(string oemCode);

    }
}
