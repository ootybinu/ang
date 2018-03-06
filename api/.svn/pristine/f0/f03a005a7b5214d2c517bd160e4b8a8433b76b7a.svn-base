using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WaterAMR.Business.Map
{
    public class UnitReportServiceMapper
    {
        public static void Map()
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<BusinessModels.GenericRequest, DataModels.GenericRequest>();
                cfg.CreateMap(typeof(BusinessModels.PagedData<>), typeof(DataModels.PagedData<>));
                cfg.CreateMap(typeof(DataModels.PagedResponse<>), typeof(BusinessModels.PagedResponse<>));

                cfg.CreateMap<DataModels.db_KeyValuePair, KeyValuePair<Int32, string>>().ConstructUsing(d => new KeyValuePair<int, string>(d.Key, d.Value));
                cfg.CreateMap<DataModels.db_KeyValuePair_Text, KeyValuePair<string, string>>().ConstructUsing(d => new KeyValuePair<string, string>(d.key, d.value));

                cfg.CreateMap<BusinessModels.UnitReport.SearchCriteria, DataModels.UnitReport.SearchCriteria>();

                cfg.CreateMap<DataModels.UnitReport.Search, BusinessModels.UnitReport.Search>();
                cfg.CreateMap<DataModels.UnitReport.UnitReport, BusinessModels.UnitReport.UnitReport>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.id))
                .ForMember(d => d.Id, o => o.MapFrom(s => s.id))
                .ForMember(d => d.Consumer, o => o.MapFrom(s => s.consumer))
                .ForMember(d => d.Division, o => o.MapFrom(s => s.division))
                .ForMember(d => d.SubDivision, o => o.MapFrom(s => s.subdivision))
                .ForMember(d => d.ServiceStation, o => o.MapFrom(s => s.servicestation))
                .ForMember(d => d.Location, o => o.MapFrom(s => s.location))
                .ForMember(d => d.Consumptioninmcube, o => o.MapFrom(s => s.consumptioninmcube))
                .ForMember(d => d.DayConsumption, o => o.MapFrom(s => s.dayconsumption))
                .ForMember(d => d.DateRecorded, o => o.MapFrom(s => s.daterecorded))
                .ForMember(d => d.OEMName, o => o.MapFrom(s => s.oemname))
                .ForMember(d => d.UnitId, o => o.MapFrom(s => s.unitid))
                .ForMember(d => d.InstallOn, o => o.MapFrom(s => s.installon))
                .ForMember(d => d.BatteryVoltage, o => o.MapFrom(s => s.batteryvoltage));

            });

        }
    }
}
