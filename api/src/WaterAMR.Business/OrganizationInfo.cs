using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterAMR.Business.Map;
using WaterAMR.BusinessModels;
using WaterAMR.DataAccess.Interfaces;

namespace WaterAMR.Business
{
    public class OrganizationInfo : Interfaces.IOrganizationInfo
    {
        public IOrganizationRepository Repository;
        public OrganizationInfo(IOrganizationRepository repository)
        {
            this.Repository = repository;
            OrganizationMapper.Map();
        }
        //public OrganizationInfo()
        //{
        //    OrganizationMapper.Map();
        //}
        public IEnumerable<Org> GetOrganizations()
        {
            //var res = this.Repository.Orgs;
            var result = this.Repository.GetOrganizations();
            
            var bo = Mapper.Map<IEnumerable<BusinessModels.Org>>(result);
            return bo;
            
        }
    }
}
