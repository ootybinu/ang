using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterAMR.Business.Interfaces;
using WaterAMR.Business.Map;
using WaterAMR.BusinessModels.Tariff;
using WaterAMR.DataAccess.Interfaces;
using WaterAMR.BusinessModels;
using WaterAMR.BusinessModels.Billing;

namespace WaterAMR.Business
{
    public class TariffService : ITariffService
    {
        private ITariffRepository Repository;
        public TariffService(ITariffRepository repos)
        {
            Repository = repos;
            TariffMapper.Map();
        }
        public string Generate(TariffInput input)
        {
            return Repository.Generate(Mapper.Map<DataModels.Tariff.TariffInput>(input));
        }

        public PagedResponse<TariffMasterFull> GetTariffConfig(PagedData<TariffInput> input)
        {
            var result = Repository.GetTariffConfig(Mapper.Map<DataModels.PagedData<DataModels.Tariff.TariffInput>>(input));
            return Mapper.Map<BusinessModels.PagedResponse<BusinessModels.Tariff.TariffMasterFull>>(result);

        }
        public string Update(BusinessModels.Billing.TariffMaster tariff)
        {
            return Repository.Update(Mapper.Map<DataModels.Billing.TariffMaster>(tariff));
        }
        public string Delete(BusinessModels.Billing.TariffMaster tariff) {
            return Repository.Delete(Mapper.Map<DataModels.Billing.TariffMaster>(tariff));
        }
    }
}
