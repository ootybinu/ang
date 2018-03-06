using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterAMR.Business.Interfaces;
using WaterAMR.Business.Map;
using WaterAMR.DataAccess.Interfaces;

namespace WaterAMR.Business
{
    public class CommonService : ICommonService
    {
        private ICommonRepository Repository;
        public CommonService(ICommonRepository repos)
        {
            this.Repository = repos;
            CommonMapper.Map();
        }
        public IEnumerable<KeyValuePair<int, string>> GetPlaceList(int parentId, int typeId) {
            return Mapper.Map<IEnumerable<KeyValuePair<int, string>>>(this.Repository.GetPlaceList(parentId, typeId));

        }
        public IEnumerable<KeyValuePair<int, string>> GetFromOrganization(int key)
        {
            return Mapper.Map<IEnumerable<KeyValuePair<Int32, string>>>(this.Repository.GetFromOrganization(key));
        }

        public IEnumerable<KeyValuePair<string, string>> GetMasterValues(string key)
        {
            return Mapper.Map<IEnumerable<KeyValuePair<string,string>>>( this.Repository.GetMasterValues(key));
        }
        public IEnumerable<KeyValuePair<int, string>> GetBillingGroups() {
            return Mapper.Map<IEnumerable<KeyValuePair<int, string>>>(this.Repository.GetBillingGroups());
        }
        public void Add() {
            this.Repository.Add();
        }
    }
}
