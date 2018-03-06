using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterAMR.DataModels;
using WaterAMR.DataModels.Tariff;

namespace WaterAMR.DataAccess.Interfaces
{
    public interface ITariffRepository
    {
        string Generate(TariffInput input);
        PagedResponse<DataModels.Tariff.TariffMasterFull> GetTariffConfig(PagedData<TariffInput> input);
        string Update(DataModels.Billing.TariffMaster tariff);
        string Delete(DataModels.Billing.TariffMaster tariff);
    }
}
