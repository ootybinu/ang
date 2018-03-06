using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WaterAMR.Business.Map
{
    public class UnitSummaryMapper
    {
        public static void Map()
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap(typeof(BusinessModels.PagedData<>), typeof(DataModels.PagedData<>));
                cfg.CreateMap(typeof(DataModels.PagedResponse<>), typeof(BusinessModels.PagedResponse<>));
                cfg.CreateMap<BusinessModels.UnitSummary.SearchParam, DataModels.UnitSummary.SearchParam>();
                cfg.CreateMap<BusinessModels.UnitSummary.UnitSummary, DataModels.UnitSummary.UnitSummary>();

                cfg.CreateMap<DataModels.UnitSummary.UnitSummaryRow, BusinessModels.UnitSummary.UnitSummaryRow>();
                cfg.CreateMap<DataModels.db_KeyValuePair_Text, KeyValuePair<string, string>>()
                    .ConvertUsing(d => new KeyValuePair<string, string>(d.key, d.value));
                cfg.CreateMap<DataModels.db_KeyValuePair, KeyValuePair<Int32, string>>()
                    .ConvertUsing(d => new KeyValuePair<Int32, string>(d.Key, d.Value));
                cfg.CreateMap<DataModels.UnitSummary.UnitSummary, BusinessModels.UnitSummary.UnitSummary>();
                cfg.CreateMap<DataModels.UnitSummary.UnitSummaySelectionLists, BusinessModels.UnitSummary.UnitSummaySelectionLists>();
                cfg.CreateMap<DataModels.UnitSummary.UnitSummaryResult, BusinessModels.UnitSummary.UnitSummaryResult>();
            });

        }
   }
}
