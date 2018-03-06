using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WaterAMR.Business.Map
{
    public class TamperDetectionMapper
    {
        public static void Map()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap(typeof(BusinessModels.PagedData<>), typeof(DataModels.PagedData<>));
                cfg.CreateMap(typeof(DataModels.PagedResponse<>), typeof(BusinessModels.PagedResponse<>));

                cfg.CreateMap<BusinessModels.TamperDetection.TamperCriteria, DataModels.TamperDetection.TamperCriteria>();
                cfg.CreateMap<DataModels.TamperDetection.TamperData,BusinessModels.TamperDetection.TamperData>();
            });
        }
    }
}
