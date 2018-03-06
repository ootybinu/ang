using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterAMR.Business.Interfaces;
using WaterAMR.Business.Map;
using WaterAMR.BusinessModels;
using WaterAMR.BusinessModels.Payment;
using WaterAMR.DataAccess.Interfaces;

namespace WaterAMR.Business
{
    public class PaymentService : IPaymentService
    {
        private IPaymentRepository Repository;
        public PaymentService(IPaymentRepository repos)
        {
            Repository = repos;
            PaymentMapper.Map();
        }
        public string AddPayment(PaymentDetail detail)
        {
            return Repository.AddPayment(Mapper.Map<DataModels.Payment.PaymentDetail>(detail));

        }
        public PaymentResultVM GetPayments(long BillNo)
        {
            return Mapper.Map<BusinessModels.Payment.PaymentResultVM>(Repository.GetPayments(BillNo));
        }
        public string CancelPayment(long PaymentId)
        {
            return Repository.CancelPayment(PaymentId);
        }
        public PaymentAuthenticationVM GetAuthenticationData(string date)
        {
            return Mapper.Map<BusinessModels.Payment.PaymentAuthenticationVM>(Repository.GetAuthenticationData(date));
        }
        public string Authenticate(string date) {
            return Repository.Authenticate(date);
        }
        public PagedResponse<PaymentProcess> Process(PagedData<ProcessInput> input)
        {
            var criteria = Mapper.Map<DataModels.PagedData<DataModels.Payment.ProcessInput>>(input);
            return Mapper.Map<PagedResponse<BusinessModels.Payment.PaymentProcess>>(Repository.Process(criteria));
        }
    }
}
