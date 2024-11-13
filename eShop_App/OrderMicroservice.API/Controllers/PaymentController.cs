using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderMicroservice.ApplicationCore.Contracts.Services;
using OrderMicroservice.ApplicationCore.Models.Request;
using OrderMicroservice.Infrastructure.Services;

namespace OrderMicroservice.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentServiceAsync paymentServiceAsync;
        private readonly IMapper mapper;

        public PaymentController(IPaymentServiceAsync paymentServiceAsync,IMapper mapper)
        {
            this.paymentServiceAsync = paymentServiceAsync;
            this.mapper = mapper;
        }
        //GetPaymentByCustomerId
        [HttpGet]
        public async Task<IActionResult> GetPaymentByCustomerId(int id)
        {
            return Ok(await paymentServiceAsync.GetPaymentMethodByCustomerId(id));
        }
        //SavePayment
        [HttpPost]
        public async Task<IActionResult> SavePayment(PaymentMethodRequestModel paymentMethod)
        {
            return Ok(await paymentServiceAsync.SavePaymentMethod(paymentMethod));
        }
        //DeletePayment
        [HttpDelete]
        public async Task<IActionResult> DeletePayment(int id)
        {
            return Ok(await paymentServiceAsync.DeletePaymentMethod(id));
        }
        //UpdatePayment
        [HttpPut]
        public async Task<IActionResult> UpdatePayment(PaymentMethodRequestModel paymentMethod, int id)
        {
            return Ok(await paymentServiceAsync.UpdatePaymentMethod(paymentMethod, id));
        }
    }
}
