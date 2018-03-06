using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WaterAMR.Business.Map
{
    public class UnitConsumptionServiceMapper
    {
        public static void Map()
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<BusinessModels.GenericRequest, DataModels.GenericRequest>();
                cfg.CreateMap(typeof(BusinessModels.PagedData<>), typeof(DataModels.PagedData<>));
                cfg.CreateMap(typeof(DataModels.PagedResponse<>), typeof(BusinessModels.PagedResponse<>));
                cfg.CreateMap<BusinessModels.Realtime.SearchParam, DataModels.Realtime.SearchParam>();
                cfg.CreateMap<BusinessModels.Realtime.UnitConsumptionHistoryInput, DataModels.Realtime.UnitConsumptionHistoryInput>();
                cfg.CreateMap<BusinessModels.UnitSummary.MessageRejectedInput, DataModels.UnitSummary.MessageRejectedInput>();

                cfg.CreateMap<DataModels.Realtime.UnitConsumption, BusinessModels.Realtime.UnitConsumption>();

                cfg.CreateMap<DataModels.db_KeyValuePair, KeyValuePair<Int32, string>>().ConstructUsing(d => new KeyValuePair<int, string>( d.Key, d.Value));
                cfg.CreateMap<DataModels.db_KeyValuePair_Text, KeyValuePair<string, string>>().ConstructUsing(d => new KeyValuePair<string, string>(d.key, d.value));
                cfg.CreateMap<DataModels.MasterData, BusinessModels.MasterData>();

                cfg.CreateMap<DataModels.Realtime.UnitConsumptionSearch, BusinessModels.Realtime.UnitConsumptionSearch>();
                cfg.CreateMap(typeof(DataModels.point<>), typeof(BusinessModels.point <>));
                cfg.CreateMap(typeof(DataModels.Graph<>), typeof(BusinessModels.Graph<>));
                cfg.CreateMap (typeof(DataModels.Realtime.UnitConsumptionGraph<>),typeof(BusinessModels.Realtime.UnitConsumptionGraph<>));

                cfg.CreateMap<DataModels.Realtime.UnitConsumptionHistory, BusinessModels.Realtime.UnitConsumptionHistory>();
                cfg.CreateMap<DataModels.UnitSummary.MessageRejected, BusinessModels.UnitSummary.MessageRejected>();
            });
        }
    }
}
