using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterAMR.BusinessModels;
using WaterAMR.BusinessModels.User;

namespace WaterAMR.Business.Interfaces
{
    public interface IUserService
    {
        PagedResponse<employeeRow> GetAllUsers(PagedData<SearchCriteria> criteria);
        employeeResponse GetUser(Int32 id);
        bool UpdateUser(employeeFull user);
        IEnumerable<KeyValuePair<Int32,string>> GetRoles();
        bool UpdatePassword(string username, string pwd);
        IEnumerable<KeyValuePair<Int32, string>> GetOrganization();

    }
}
