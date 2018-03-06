using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterAMR.DataModels.Dashboard;

namespace WaterAMR.DataAccess.Interfaces
{
    public interface IDashboardRepository
    {
        ConsumptionData GetConsumptionData(ConsumptionInput input);
        List<KeyValuePair<string, decimal>> GetDivisionWise(ConsumptionInput input);
        List<KeyValuePair<string, decimal>> GetOemWise(ConsumptionInput input);
        List<KeyValuePair<string, string>> GetMessageData(ConsumptionInput input);
    }
}
