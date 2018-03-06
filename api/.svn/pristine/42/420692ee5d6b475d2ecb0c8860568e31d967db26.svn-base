using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WaterAMR.Business.Map
{
    public class UserMapper
    {
        public static void Map()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap(typeof(BusinessModels.PagedData<>), typeof(DataModels.PagedData<>));
                cfg.CreateMap(typeof(DataModels.PagedResponse<>), typeof(BusinessModels.PagedResponse<>));
                cfg.CreateMap<BusinessModels.User.SearchCriteria, DataModels.User.SearchCriteria>();
                cfg.CreateMap<BusinessModels.User.employee, DataModels.User.employee>();
                cfg.CreateMap<BusinessModels.User.loginmaster, DataModels.User.loginmaster>();


                cfg.CreateMap<BusinessModels.User.employeeFull, DataModels.User.employeeFull>();
                cfg.CreateMap<DataModels.User.employeeRow, BusinessModels.User.employeeRow >();
                cfg.CreateMap<DataModels.db_KeyValuePair, KeyValuePair<Int32, string>>()
                   .ConvertUsing(d => new KeyValuePair<Int32, string>(d.Key, d.Value));
                cfg.CreateMap<DataModels.User.employeeFull, BusinessModels.User.employeeFull>();
                
                cfg.CreateMap<DataModels.User.employeeResponse, BusinessModels.User.employeeResponse>();
                cfg.CreateMap<DataModels.User.employee, BusinessModels.User.employee>();
                cfg.CreateMap<DataModels.User.loginmaster, BusinessModels.User.loginmaster>();


            });
       }
    }
}
