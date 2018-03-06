using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterAMR.BusinessModels.Dashboard;

namespace WaterAMR.Business.Map
{
    public class DashboardMapper
    {
        public static void Map()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<BusinessModels.Dashboard.ConsumptionInput, DataModels.Dashboard.ConsumptionInput>();
                cfg.CreateMap<KeyValuePair<string, decimal>, NameValuePair<string, decimal>>()
                .ForMember(d => d.value, o => o.MapFrom(s => s.Value))
                .ForMember(d => d.name, o => o.MapFrom(s => s.Key));
            }
            );
        }
    }
}
