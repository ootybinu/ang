using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WaterAMR.Business.Map
{
    public class RoleMapper
    {
        public static void Map()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap(typeof(BusinessModels.PagedData<>), typeof(DataModels.PagedData<>));
                cfg.CreateMap(typeof(DataModels.PagedResponse<>), typeof(BusinessModels.PagedResponse<>));
                cfg.CreateMap<BusinessModels.Role.Role, DataModels.Role.Role>();
                cfg.CreateMap<BusinessModels.Security.Menu, DataModels.Role.Menu>();
                cfg.CreateMap<BusinessModels.Security.MenuTree, DataModels.Security.MenuTree>();

                cfg.CreateMap<BusinessModels.Role.menu, DataModels.Role.menu>();
                cfg.CreateMap<BusinessModels.Role.menuprivileges, DataModels.Role.menuprivileges>();
                cfg.CreateMap<BusinessModels.Role.RoleResponse, DataModels.Role.RoleResponse>();
                cfg.CreateMap<BusinessModels.Role.SearchCriteria, DataModels.Role.SearchCriteria>();
                cfg.CreateMap<DataModels.Role.Role, BusinessModels.Role.Role>();
                cfg.CreateMap<DataModels.Role.menu, BusinessModels.Role.menu>();
                cfg.CreateMap<DataModels.Role.RoleResponse, BusinessModels.Role.RoleResponse>();
                cfg.CreateMap<DataModels.Role.menuprivileges, BusinessModels.Role.menuprivileges>();
                cfg.CreateMap<DataModels.Role.Menu, BusinessModels.Security.Menu>();
                cfg.CreateMap<DataModels.Security.MenuTree, BusinessModels.Security.MenuTree>();


            });
        }
    }
}
