using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterAMR.DataModels;
using WaterAMR.DataModels.Payment;

namespace WaterAMR.DataAccess.Interfaces
{
    public interface IPaymentRepository
    {
        string AddPayment(PaymentDetail detail);
        PaymentResultVM GetPayments(long BillNo);
        string CancelPayment(long PaymentId);
        PaymentAuthenticationVM GetAuthenticationData(string date);
        string Authenticate(string date);
        PagedResponse<PaymentProcess> Process(PagedData<ProcessInput> input);
    }
}
