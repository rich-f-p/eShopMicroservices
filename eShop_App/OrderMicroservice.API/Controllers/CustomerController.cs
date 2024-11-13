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
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerServiceAsync serviceAsync;

        public CustomerController(ICustomerServiceAsync serviceAsync)
        {
            this.serviceAsync = serviceAsync;
        }
        //GetCustomerAddressByUserId
        [HttpGet]
        public async Task<IActionResult> GetCustomerAddressByUserId(int id)
        {
            return Ok(await serviceAsync.GetCustomerAddressByUserId(id));
        }
        //SaveCustomerAddress
        [HttpPost]
        public async Task<IActionResult> SaveCustomerAddress(AddressRequestModel address, int customerId)
        {
            return Ok(await serviceAsync.SaveCustomerAddress(address, customerId));
        }
    }
}
