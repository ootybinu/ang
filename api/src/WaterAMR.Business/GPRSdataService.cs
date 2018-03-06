using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterAMR.Business.Interfaces;
using WaterAMR.Business.Map;
using WaterAMR.BusinessModels.GPRSdata;
using WaterAMR.DataAccess.Interfaces;

namespace WaterAMR.Business
{
    public class GPRSdataService : IGPRSdataService
    {
        private IGPRSdataRepository Repository;
        public GPRSdataService(IGPRSdataRepository repository)
        {
            this.Repository = repository;
            GPRSdataServiceMapper.Map();
        } 
        public IEnumerable<GprsData> GetGprsData(string onDate)
        {
            var data = Repository.GetGprsData(onDate);
            var result = Mapper.Map<IEnumerable<BusinessModels.GPRSdata.GprsData>>(data);
            return result;
        }

        public IEnumerable<GprsDetail> GetGprsDetail(string id, string ondate)
        {
            var data = Repository.GetGprsDetail(id, ondate);
            var result = Mapper.Map<IEnumerable<BusinessModels.GPRSdata.GprsDetail>>(data);
            return result;
        }

        public IEnumerable<GprsDetail> GetGprsHistory(string id)
        {
            var data = Repository.GetGprsHistory(id);
            var result = Mapper.Map<IEnumerable<BusinessModels.GPRSdata.GprsDetail>>(data);
            return result;
        }
    }
}
