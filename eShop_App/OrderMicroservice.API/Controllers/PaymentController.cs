//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using OrderMicroservice.ApplicationCore.Models.Request;
//using OrderMicroservice.Infrastructure.Services;

//namespace OrderMicroservice.API.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class PaymentController : ControllerBase
//    {
//        private readonly PaymentServiceAsync paymentServiceAsync;

//        public PaymentController(PaymentServiceAsync paymentServiceAsync)
//        {
//            this.paymentServiceAsync = paymentServiceAsync;
//        }
//        //GetPaymentByCustomerId
//        [HttpGet]
//        public async Task<IActionResult> GetPaymentByCustomerId(int id)
//        {
//            return Ok(await paymentServiceAsync.GetPaymentMethodByCustomerId(id));
//        }
//        //SavePayment
//        [HttpPost]
//        public async Task<IActionResult> SavePayment(Payment_TypeRequestModel paymentType, PaymentMethodRequestModel paymentMethod)
//        {
//            return Ok(await paymentServiceAsync.SavePaymentMethod(paymentType,paymentMethod));
//        }
//        //DeletePayment
//        [HttpDelete]
//        public async Task<IActionResult> DeletePayment(int id)
//        {
//            return Ok(await paymentServiceAsync.DeletePaymentMethod(id));
//        }
//        //UpdatePayment
//        [HttpPut]
//        public async Task<IActionResult> UpdatePayment(PaymentMethodRequestModel paymentMethod, int id)
//        {
//            return Ok(await paymentServiceAsync.UpdatePaymentMethod(paymentMethod,id));
//        }
//    }
//}
