using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WaterAMR.Business.Map
{
    public class CommonMapper
    {
        public static void Map()
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<DataModels.db_KeyValuePair_Text, KeyValuePair<string, string>>().ConstructUsing(d => new KeyValuePair<string, string>(d.key, d.value));
                cfg.CreateMap<DataModels.db_KeyValuePair, KeyValuePair<Int32, string>>().ConstructUsing(d => new KeyValuePair<Int32, string>(d.Key, d.Value));
            });

        }
    }
}
