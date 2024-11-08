using OrderMicroservice.ApplicationCore.Models.Request;
using OrderMicroservice.ApplicationCore.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMicroservice.ApplicationCore.Contracts.Services
{
    public interface IPaymentServiceAsync
    {
        Task<PaymentMethodResponseModel> GetPaymentMethodByCustomerId(int id);
        Task<int> SavePaymentMethod(Payment_TypeRequestModel paymentType, PaymentMethodRequestModel paymentMethod);
        Task<int> DeletePaymentMethod(int id);
        Task<int> UpdatePaymentMethod(PaymentMethodRequestModel paymentMethod,int id);
    }
}
