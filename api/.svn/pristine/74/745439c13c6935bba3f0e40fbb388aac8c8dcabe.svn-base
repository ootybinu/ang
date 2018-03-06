using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WaterAMR.Business.Map
{
    public class OemMapper
    {
        public static void Map() {
            Mapper.Initialize(cfg => {
                cfg.CreateMap(typeof(BusinessModels.PagedData<>), typeof(DataModels.PagedData<>));
                cfg.CreateMap(typeof(DataModels.PagedResponse<>), typeof(BusinessModels.PagedResponse<>));
                cfg.CreateMap<BusinessModels.Oem.OemInput, DataModels.Oem.OemInput>();

                cfg.CreateMap<BusinessModels.Oem.Oem, DataModels.Oem.Oem>();
                cfg.CreateMap<DataModels.Oem.oemeffiency, BusinessModels.Oem.oemeffiency>();
                cfg.CreateMap<DataModels.Oem.Oem, BusinessModels.Oem.Oem>();
                cfg.CreateMap<DataModels.Oem.oemefficiencydetail, BusinessModels.Oem.oemefficiencydetail>();

            });
        }
    }
}
