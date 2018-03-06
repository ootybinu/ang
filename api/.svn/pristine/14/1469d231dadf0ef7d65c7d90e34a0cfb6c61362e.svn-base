using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WaterAMR.Business.Map
{
    public class RevenueMapper
    {
        public static void Map()
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap(typeof(BusinessModels.PagedData<>), typeof(DataModels.PagedData<>));
                cfg.CreateMap(typeof(DataModels.PagedResponse<>), typeof(BusinessModels.PagedResponse<>));
                cfg.CreateMap<BusinessModels.Revenue.RevenueInput, DataModels.Revenue.RevenueInput>();
                cfg.CreateMap<DataModels.Revenue.Revenue, BusinessModels.Revenue.Revenue>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.id))
                .ForMember(d => d.MeterType, o => o.MapFrom(s => s.meterbillingtype))
                .ForMember(d => d.Name, o => o.MapFrom(s => s.name))
                .ForMember(d => d.OEM, o => o.MapFrom(s => s.oem))
                .ForMember(d => d.revenue, o => o.MapFrom(s => s.revenue))
                .ForMember(d => d.RRNumber, o => o.MapFrom(s => s.rrnumber))
                .ForMember(d => d.SubDivision, o => o.MapFrom(s => s.subdivision))
                .ForMember(d => d.TotalConsumption, o => o.MapFrom(s => s.totalconsumption))
                .ForMember(d => d.Unit, o => o.MapFrom(s => s.unit))
                ;

            });

        }
    }
}
