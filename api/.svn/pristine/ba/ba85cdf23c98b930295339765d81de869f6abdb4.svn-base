using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterAMR.DataModels;
using WaterAMR.DataModels.User;

namespace WaterAMR.DataAccess.Interfaces
{
    public interface IUserRepository
    {
        PagedResponse<employeeRow> GetAllUsers(PagedData<SearchCriteria> criteria);
        employeeResponse GetUser(Int32 id);
        bool UpdateUser(employeeFull user);
        IEnumerable<db_KeyValuePair> GetRoles();
        bool UpdatePassword(string username, string pwd);
        IEnumerable<db_KeyValuePair> GetOrganization();
    }
}
