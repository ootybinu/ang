using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WaterAMR.Business.Map
{
    public class TariffMapper
    {
        public static void Map()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap(typeof(BusinessModels.PagedData<>), typeof(DataModels.PagedData<>));
                cfg.CreateMap(typeof(DataModels.PagedResponse<>), typeof(BusinessModels.PagedResponse<>));
                cfg.CreateMap<BusinessModels.Tariff.TariffInput, DataModels.Tariff.TariffInput>();
                cfg.CreateMap<BusinessModels.Billing.TariffMaster, DataModels.Billing.TariffMaster>();
//                cfg.CreateMap<DataModels.Billing.TariffMaster, BusinessModels.Billing.TariffMaster>();
                cfg.CreateMap<DataModels.Tariff.TariffMasterFull, BusinessModels.Tariff.TariffMasterFull>();

            });
        }
            }
}
