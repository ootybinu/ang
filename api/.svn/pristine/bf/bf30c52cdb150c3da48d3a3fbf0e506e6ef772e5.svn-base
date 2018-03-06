using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterAMR.BusinessModels;
using WaterAMR.BusinessModels.Oem;

namespace WaterAMR.Business.Interfaces
{
    public interface IOemService
    {
        PagedResponse<Oem> GetAll(PagedData<OemInput> input);
        string Save(Oem input);
        IEnumerable<oemeffiency> GetOemEffiency();
        IEnumerable<oemefficiencydetail> GetOemEfficiencyDetail(string oemCode);

    }
}
