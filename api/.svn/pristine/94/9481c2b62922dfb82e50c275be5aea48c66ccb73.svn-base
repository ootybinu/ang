using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterAMR.Business.Interfaces;
using WaterAMR.Business.Map;
using WaterAMR.BusinessModels;
using WaterAMR.BusinessModels.Oem;
using WaterAMR.DataAccess.Interfaces;

namespace WaterAMR.Business
{
    public class OemService : IOemService
    {
        private IOemRepository Repository;
        public OemService(IOemRepository repos)
        {
            Repository = repos;
            OemMapper.Map();
        }
        public PagedResponse<Oem> GetAll(PagedData<OemInput> input)
        {
            var inp = Mapper.Map<DataModels.PagedData<DataModels.Oem.OemInput>>(input);
            var result = Repository.GetAll(inp);
            return Mapper.Map<BusinessModels.PagedResponse<BusinessModels.Oem.Oem>>(result);
        }

        public IEnumerable<oemefficiencydetail> GetOemEfficiencyDetail(string oemCode)
        {
            var result = Repository.GetOemEfficiencyDetail(oemCode);
            return Mapper.Map<IEnumerable<BusinessModels.Oem.oemefficiencydetail>>(result);
        }

        public IEnumerable<oemeffiency> GetOemEffiency()
        {
            var result = Repository.GetOemEffiency();
            return Mapper.Map<IEnumerable<BusinessModels.Oem.oemeffiency>>(result);
        }

        public string Save(Oem input)
        {
            var inp = Mapper.Map<DataModels.Oem.Oem>(input);
            return Repository.Save(inp);
        }
    }
}
