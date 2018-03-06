using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WaterAMR.Business.Map
{
    public class PaymentMapper
    {
        public static void Map()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap(typeof(BusinessModels.PagedData<>), typeof(DataModels.PagedData<>));
                cfg.CreateMap(typeof(DataModels.PagedResponse<>), typeof(BusinessModels.PagedResponse<>));
                cfg.CreateMap<BusinessModels.Payment.PaymentDetail, DataModels.Payment.PaymentDetail>();
                cfg.CreateMap<BusinessModels.Payment.ProcessInput, DataModels.Payment.ProcessInput>();

                cfg.CreateMap<DataModels.Payment.PaymentDetail, BusinessModels.Payment.PaymentDetail>();
                cfg.CreateMap<DataModels.Payment.PaymentResultVM, BusinessModels.Payment.PaymentResultVM>();

                cfg.CreateMap<DataModels.Payment.PaymentAuthenticationVM, BusinessModels.Payment.PaymentAuthenticationVM>();
                cfg.CreateMap<DataModels.Payment.PaymentAuthenticaionResult, BusinessModels.Payment.PaymentAuthenticaionResult>();
                cfg.CreateMap<DataModels.Payment.PaymentProcess, BusinessModels.Payment.PaymentProcess>();
                cfg.CreateMap<DataModels.Billing.Bill, BusinessModels.Billing.Bill>();
            });
        }
   }
}
