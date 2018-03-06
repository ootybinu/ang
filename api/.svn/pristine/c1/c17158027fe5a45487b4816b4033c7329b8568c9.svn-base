using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WaterAMR.Business.Map
{
    public class BillingMapper
    {
        public static void Map()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap(typeof(BusinessModels.PagedData<>), typeof(DataModels.PagedData<>));
                cfg.CreateMap(typeof(DataModels.PagedResponse<>), typeof(BusinessModels.PagedResponse<>));
                cfg.CreateMap<BusinessModels.Billing.BillFilter, DataModels.Billing.BillFilter>();
                cfg.CreateMap<BusinessModels.Billing.BillGenerateInput, DataModels.Billing.BillGenerateInput>();
                cfg.CreateMap<BusinessModels.Billing.BGInput, DataModels.Billing.BGInput>();
                cfg.CreateMap<BusinessModels.Billing.BillGroup, DataModels.Billing.BillGroup>();
                cfg.CreateMap<BusinessModels.Billing.BillGroupDetail, DataModels.Billing.BillGroupDetail>();
                cfg.CreateMap<DataModels.Billing.Bill, BusinessModels.Billing.Bill>();
                cfg.CreateMap<DataModels.Billing.BillDetail, BusinessModels.Billing.BillDetail>();
                
                cfg.CreateMap<DataModels.User.employee, BusinessModels.User.employee>();
                cfg.CreateMap<DataModels.UnitSummary.UnitSummary, BusinessModels.UnitSummary.UnitSummary>();
                cfg.CreateMap<DataModels.Billing.BillGroupResult, BusinessModels.Billing.BillGroupResult>();
                cfg.CreateMap<DataModels.Billing.BillGroup, BusinessModels.Billing.BillGroup>();
                cfg.CreateMap<DataModels.Billing.BillGroupDetail, BusinessModels.Billing.BillGroupDetail>();
                cfg.CreateMap<DataModels.Billing.BillGroupDetailVM, BusinessModels.Billing.BillGroupDetailVM>();
            });
        }
    }
}
