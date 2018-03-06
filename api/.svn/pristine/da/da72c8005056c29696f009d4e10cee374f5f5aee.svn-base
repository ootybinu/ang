using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterAMR.BusinessModels;
using WaterAMR.BusinessModels.Tariff;

namespace WaterAMR.Business.Interfaces
{
    public interface ITariffService
    {
        string Generate(TariffInput input);
        PagedResponse<BusinessModels.Tariff.TariffMasterFull> GetTariffConfig(PagedData<TariffInput> input);
        string Update(BusinessModels.Billing.TariffMaster tariff);
        string Delete(BusinessModels.Billing.TariffMaster tariff);
    }
}
