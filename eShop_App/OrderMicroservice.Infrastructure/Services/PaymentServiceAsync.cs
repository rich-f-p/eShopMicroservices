//using AutoMapper;
//using OrderMicroservice.ApplicationCore.Contracts.Services;
//using OrderMicroservice.ApplicationCore.Entities;
//using OrderMicroservice.ApplicationCore.Models.Request;
//using OrderMicroservice.ApplicationCore.Models.Response;
//using OrderMicroservice.Infrastructure.Repository;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace OrderMicroservice.Infrastructure.Services
//{
//    public class PaymentServiceAsync : IPaymentServiceAsync
//    {
//        private readonly PaymentMethodRepositoryAsync paymentMethodRepo;
//        private readonly IMapper mapper;
//        private readonly Payment_TypeRepositoryAsync paymentTypeRepo;

//        public PaymentServiceAsync(PaymentMethodRepositoryAsync paymentMethodRepo, IMapper mapper, Payment_TypeRepositoryAsync paymentTypeRepo)
//        {
//            this.paymentMethodRepo = paymentMethodRepo;
//            this.mapper = mapper;
//            this.paymentTypeRepo = paymentTypeRepo;
//        }
//        public async Task<int> DeletePaymentMethod(int id)
//        {
//            return await paymentMethodRepo.DeleteAsync(id);
//        }

//        public async Task<PaymentMethodResponseModel> GetPaymentMethodByCustomerId(int id)
//        {
//            return mapper.Map<PaymentMethodResponseModel>( await paymentMethodRepo.GetPaymentMethodByCustomerIdAsync(id));
//        }

//        public async Task<int> SavePaymentMethod(Payment_TypeRequestModel paymentType,PaymentMethodRequestModel paymentMethod)
//        {
//            var typeId = await paymentTypeRepo.InsertAsync(mapper.Map<Payment_Type>(paymentType));
//            paymentMethod.Payment_Type_Id = typeId;
//            return await paymentMethodRepo.InsertAsync(mapper.Map<PaymentMethod>( paymentMethod));
//        }

//        public async Task<int> UpdatePaymentMethod(PaymentMethodRequestModel paymentMethod, int id)
//        {
//            if(paymentMethod.Id == id)
//            {
//                return await paymentMethodRepo.UpdateAsync(mapper.Map<PaymentMethod>( paymentMethod));
//            }
//            return 0;
//        }
//    }
//}
