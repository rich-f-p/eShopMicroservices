using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderMicroservice.ApplicationCore.Contracts.Services;
using OrderMicroservice.ApplicationCore.Models.Request;
using OrderMicroservice.Infrastructure.Services;

namespace OrderMicroservice.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderServiceAsync orderServiceAsync;

        public OrderController(IOrderServiceAsync orderServiceAsync)
        {
            this.orderServiceAsync = orderServiceAsync;
        }
        //GetAllOrders
        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            return Ok( await orderServiceAsync.GetAllOrders());
        }
        //SaveOrder
        [HttpPost]
        public async Task<IActionResult> SaveOrder(OrderRequestModel model)
        {
            return Ok(await orderServiceAsync.SaveOrder(model));
        }
        //CheckOrderHistory
        [HttpGet]
        public async Task<IActionResult> CheckOrderHistory(int id)
        {
            return Ok(await orderServiceAsync.CheckOrderHistory(id));
        }
        //CheckOrderStatus
        [HttpGet]
        public async Task<IActionResult> CheckOrderStatus(int id)
        {
            return Ok(await orderServiceAsync.CheckOrderHistory(id));
        }
        //CancelOrder
        [HttpPut]
        public async Task<IActionResult> CancelOrder(int id)
        {
            return Ok(await orderServiceAsync.CancelOrder(id));
        }
        //OrderCompleted
        [HttpPost]
        public async Task<IActionResult> OrderCompleted(int id)
        {
            return Ok(await orderServiceAsync.OrderCompleted(id));
        }
        //UpdateOrder
        [HttpPut]
        public async Task<IActionResult> UpdateOrder(OrderRequestModel model,int id)
        {
            return Ok(await orderServiceAsync.UpdateOrder(model,id));
        }
    }
}
