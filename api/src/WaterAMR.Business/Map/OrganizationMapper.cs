using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WaterAMR.Business.Map
{
    public class OrganizationMapper
    {
        public OrganizationMapper()
        {

        }
        public static void Map()
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap <WaterAMR.DataModels.Org, WaterAMR.BusinessModels.Org>();
                cfg.CreateMap<BusinessModels.Organization.OrgInput, DataModels.Organization.OrgInput>();
                cfg.CreateMap<DataModels.Organization.OrgShort, BusinessModels.Organization.OrgShort>();
                cfg.CreateMap<BusinessModels.Organization.OrgShort, DataModels.Organization.OrgShort>();
            }
            
            );
        }
    }
}
