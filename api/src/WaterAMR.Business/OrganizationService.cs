using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterAMR.Business.Interfaces;
using WaterAMR.Business.Map;
using WaterAMR.BusinessModels.Organization;
using WaterAMR.DataAccess.Interfaces;

namespace WaterAMR.Business
{
    public class OrganizationService : IOrganizationService
    {
        private IOrganizationRepository Repository;
        public OrganizationService(IOrganizationRepository repos)
        {
            Repository = repos;
            OrganizationMapper.Map();
        }

        public string AddOrg(OrgShort org)
        {
            var input = Mapper.Map<DataModels.Organization.OrgShort>(org);
            return Repository.AddOrg(input);
        }

        public string DeleteOrg(OrgShort org)
        {
            var inp = Mapper.Map<DataModels.Organization.OrgShort>(org);
            var result = Repository.DeleteOrg(inp);
            return result;
        }

        public IEnumerable<OrgShort> GetOrgMembers(OrgInput input)
        {
            var inp = Mapper.Map<DataModels.Organization.OrgInput>(input);
            var result = Repository.GetOrgMembers(inp);
            return Mapper.Map<IEnumerable<BusinessModels.Organization.OrgShort>>(result);
        }

        public string Update(OrgShort org)
        {
            var input = Mapper.Map<DataModels.Organization.OrgShort>(org);
            return Repository.UpdateOrg(input);
        }
    }
}
