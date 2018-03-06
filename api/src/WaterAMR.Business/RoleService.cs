using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterAMR.Business.Interfaces;
using WaterAMR.Business.Map;
using WaterAMR.BusinessModels;
using WaterAMR.BusinessModels.Role;
using WaterAMR.DataAccess.Interfaces;

namespace WaterAMR.Business
{
    public class RoleService : IRoleService
    {
        private IRoleRepository Repository;
        public RoleService(IRoleRepository repos)
        {
            Repository = repos;
            RoleMapper.Map();
        }
        public PagedResponse<Role> GetAll(PagedData<SearchCriteria> input)
        {
            var inp = Mapper.Map<DataModels.PagedData<DataModels.Role.SearchCriteria>>(input);
            var result = Repository.GetAll(inp);
            return Mapper.Map<BusinessModels.PagedResponse<BusinessModels.Role.Role>>(result);

        }

        public RoleResponse GetRole(int id)
        {
            var result = Repository.GetRole(id);
            return Mapper.Map<BusinessModels.Role.RoleResponse>(result);
        }

        public bool UpdateRole(RoleResponse update)
        {
            var inp = Mapper.Map<DataModels.Role.RoleResponse>(update);

            return Repository.UpdateRole(inp);
        }
    }
}
