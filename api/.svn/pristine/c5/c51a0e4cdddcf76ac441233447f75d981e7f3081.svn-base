using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterAMR.Business.Interfaces;
using WaterAMR.Business.Map;
using WaterAMR.BusinessModels;
using WaterAMR.BusinessModels.User;
using WaterAMR.DataAccess.Interfaces;

namespace WaterAMR.Business
{
    public class UserService : IUserService
    {
        private IUserRepository Repository;
        public UserService(IUserRepository repos)
        {
            Repository = repos;
            UserMapper.Map();
        }
        public PagedResponse<employeeRow> GetAllUsers(PagedData<SearchCriteria> input)
        {
            var inp = Mapper.Map<DataModels.PagedData< DataModels.User.SearchCriteria>>(input);
            var result = Repository.GetAllUsers(inp);
            return Mapper.Map<BusinessModels.PagedResponse<BusinessModels.User.employeeRow>>(result);
        }

        public IEnumerable<KeyValuePair<int, string>> GetRoles()
        {
            var result = Repository.GetRoles();
            return Mapper.Map<IEnumerable<KeyValuePair<Int32, string>>>(result);
        }
        public IEnumerable<KeyValuePair<int, string>> GetOrganization()
        {
            var result = Repository.GetOrganization();
            return Mapper.Map<IEnumerable<KeyValuePair<Int32, string>>>(result);
        }
        public employeeResponse GetUser(Int32 id)
        {
            var result = Repository.GetUser(id);
            return Mapper.Map<BusinessModels.User.employeeResponse>(result);
        }

        public bool UpdatePassword(string username, string pwd)
        {
            return Repository.UpdatePassword(username, pwd);
        }

        public bool UpdateUser(employeeFull user)
        {
            var input = Mapper.Map<DataModels.User.employeeFull>(user);
            return Repository.UpdateUser(input);
        }
    }
}
