using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterAMR.DataModels;
using WaterAMR.DataModels.Role;

namespace WaterAMR.DataAccess.Interfaces
{
    public interface IRoleRepository
    {
        PagedResponse<Role> GetAll(PagedData<SearchCriteria> input);
        RoleResponse GetRole(Int32 id);
        bool UpdateRole(RoleResponse update); 
    }
}
