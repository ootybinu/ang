using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterAMR.BusinessModels.Dashboard;

namespace WaterAMR.Business.Interfaces
{
    public interface IDashboardService
    {
        ConsumptionData<string, decimal> GetConsumptionData(ConsumptionInput userid);
        List<NameValuePair<string, decimal>> GetDivisionWise(ConsumptionInput input);
        List<NameValuePair<string, decimal>> GetOemWise(ConsumptionInput input);
        List<KeyValuePair<string, string>> GetMessageData(ConsumptionInput input);
    }
}
