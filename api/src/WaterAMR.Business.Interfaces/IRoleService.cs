using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterAMR.BusinessModels;
using WaterAMR.BusinessModels.Role;

namespace WaterAMR.Business.Interfaces
{
    public interface IRoleService
    {
        PagedResponse<Role> GetAll(PagedData<SearchCriteria> input);
        RoleResponse GetRole(Int32 id);
        bool UpdateRole(RoleResponse update);
    }
}
