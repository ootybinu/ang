using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WaterAMR.Business.Map
{
    public class SecurityMapper
    {
        public static void Map()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<DataModels.Security.User, BusinessModels.Security.User>();
                cfg.CreateMap<DataModels.Security.MenuItem, BusinessModels.Security.MenuItem>();
                cfg.CreateMap<DataModels.Role.Menu, BusinessModels.Security.Menu>();
                cfg.CreateMap<DataModels.Security.MenuTree, BusinessModels.Security.MenuTree>();
                cfg.CreateMap<DataModels.Organization.OrgInfo, BusinessModels.Organization.OrgInfo>();
                cfg.CreateMap<DataModels.Security.AuthenticationResult, BusinessModels.Security.AuthenticationResult>();
            });
        }
    }
}
