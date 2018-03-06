using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WaterAMR.Business.Interfaces
{
    public interface ICommonService
    {
        IEnumerable<KeyValuePair<string, string>> GetMasterValues(string key);
        IEnumerable<KeyValuePair<Int32, string>> GetFromOrganization(Int32 key);
        IEnumerable<KeyValuePair<int, string>> GetPlaceList(int parentId, int typeId);
        IEnumerable<KeyValuePair<int, string>> GetBillingGroups();
        
        void Add();
    }
}
