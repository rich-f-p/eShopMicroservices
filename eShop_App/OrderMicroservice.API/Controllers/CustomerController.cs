//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using OrderMicroservice.ApplicationCore.Models.Request;
//using OrderMicroservice.Infrastructure.Services;

//namespace OrderMicroservice.API.Controllers
//{
//    [Route("api/[controller]/[action]")]
//    [ApiController]
//    public class CustomerController : ControllerBase
//    {
//        private readonly CustomerServiceAsync serviceAsync;

//        public CustomerController(CustomerServiceAsync serviceAsync)
//        {
//            this.serviceAsync = serviceAsync;
//        }
//        //GetCustomerAddressByUserId
//        [HttpGet]
//        public async Task<IActionResult> GetCustomerAddressByUserId(int id)
//        {
//            return Ok(await serviceAsync.GetCustomerAddressByUserId(id));
//        }
//        //SaveCustomerAddress
//        [HttpPost]
//        public async Task<IActionResult> SaveCustomerAddress(AddressRequestModel address, int customerId)
//        {
//            return Ok(await serviceAsync.SaveCustomerAddress(address,customerId));
//        }
//    }
//}
