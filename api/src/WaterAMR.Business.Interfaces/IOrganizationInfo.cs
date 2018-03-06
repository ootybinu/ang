using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WaterAMR.Business.Interfaces
{
    public interface IOrganizationInfo
    {
        IEnumerable<BusinessModels.Org> GetOrganizations();
    }
}
