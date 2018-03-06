using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterAMR.DataModels;
using WaterAMR.DataModels.Organization;

namespace WaterAMR.DataAccess.Interfaces
{
    public interface IOrganizationRepository
    {
         IEnumerable<Org> GetOrganizations();
        //DbSet<Organization> Orgs { get; set; }
        IEnumerable<OrgShort> GetOrgMembers(OrgInput input);
        string UpdateOrg(OrgShort org);
        string AddOrg(OrgShort org);
        string DeleteOrg(OrgShort org);
    }
}
