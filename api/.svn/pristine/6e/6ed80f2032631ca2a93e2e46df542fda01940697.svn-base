using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterAMR.DataModels;

namespace WaterAMR.DataAccess.Interfaces
{
    public interface ICommonRepository
    {
        IEnumerable<db_KeyValuePair_Text> GetMasterValues(string key);
        IEnumerable<db_KeyValuePair> GetFromOrganization(Int32 key);
        IEnumerable<db_KeyValuePair> GetPlaceList(int parentId, int typeId);
        IEnumerable<db_KeyValuePair> GetBillingGroups();
        
        void Add();
    }
}
