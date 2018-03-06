using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterAMR.Business.Interfaces;
using WaterAMR.Business.Map;
using WaterAMR.BusinessModels.Dashboard;
using WaterAMR.DataAccess.Interfaces;

namespace WaterAMR.Business
{
    public class DashboardService : IDashboardService
    {
        IDashboardRepository Repository;
        public DashboardService(IDashboardRepository repos)
        {
            Repository = repos;
            DashboardMapper.Map();
        }
        public ConsumptionData<string,decimal> GetConsumptionData(ConsumptionInput input)
        {
            var inp = Mapper.Map<DataModels.Dashboard.ConsumptionInput>(input);
            var result =  Repository.GetConsumptionData(inp);
            var ret = new ConsumptionData<string, decimal>();
            var ret1 = new List<SeriesList<string,decimal>>();
            foreach (var item in result.Data)
            {
                var k = item.Key;
                var val = item.Value;
                var row = new SeriesList<string, decimal>();
                row.name = item.Key;
                row.series = new List<NameValuePair<string, decimal>>();
                foreach (var inner in val)
                {
                    var r = new NameValuePair<string, decimal>() { name=inner.Key, value = inner.Value  };
                    row.series.Add(r);
                }
                ret1.Add(row);
            }
            var ret2 = new List<SeriesList<string, decimal>>();
            foreach (var item in result.AlternateData)
            {
                var k = item.Key;
                var val = item.Value;
                var row = new SeriesList<string, decimal>();
                row.name = item.Key;
                row.series = new List<NameValuePair<string, decimal>>();
                foreach (var inner in val)
                {
                    var r = new NameValuePair<string, decimal>() { name = inner.Key, value = inner.Value };
                    row.series.Add(r);
                }
                ret2.Add(row);
            }
            ret.Data = ret1;
            ret.AlternateData = ret2;
            return ret;
        }

        public List<NameValuePair<string, decimal>> GetDivisionWise(ConsumptionInput input)
        {
            var inp = Mapper.Map<DataModels.Dashboard.ConsumptionInput>(input);
            var result = Repository.GetDivisionWise(inp);
            var ret = Mapper.Map<List<NameValuePair<string, decimal>>>(result);
            return ret;

        }
        public List<NameValuePair<string, decimal>> GetOemWise(ConsumptionInput input)
        {
            var inp = Mapper.Map<DataModels.Dashboard.ConsumptionInput>(input);
            var result = Repository.GetOemWise (inp);
            var ret = Mapper.Map<List<NameValuePair<string, decimal>>>(result);
            return ret;

        }
        public List<KeyValuePair<string, string>> GetMessageData(ConsumptionInput input)
        {
            var inp = Mapper.Map<DataModels.Dashboard.ConsumptionInput>(input);
            return Repository.GetMessageData(inp);

        }
    }
}
