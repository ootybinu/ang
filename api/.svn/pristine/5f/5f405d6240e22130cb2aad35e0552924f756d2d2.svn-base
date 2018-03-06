using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterAMR.BusinessModels.Organization;

namespace WaterAMR.Business.Interfaces
{
    public interface IOrganizationService
    {
        IEnumerable<OrgShort> GetOrgMembers(OrgInput input);
        string Update(OrgShort org);
        string AddOrg(OrgShort org);
        string DeleteOrg(OrgShort org);
    }
}
