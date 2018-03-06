using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WaterAMR.Business.Map
{
    public class GPRSdataServiceMapper
    {
        public static void Map()
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<DataModels.GPRSdata.GprsData, BusinessModels.GPRSdata.GprsData>();
                cfg.CreateMap<DataModels.GPRSdata.GprsDetail, BusinessModels.GPRSdata.GprsDetail>();

            });
        }
    }
}
