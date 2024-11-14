using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderMicroservice.ApplicationCore.Contracts.Services;
using OrderMicroservice.ApplicationCore.Models.Request;
using OrderMicroservice.ApplicationCore.Models.Response;
using OrderMicroservice.Infrastructure.Services;
using RabbitMqHelper;
using System.Text.Json;

namespace OrderMicroservice.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(Roles ="Customer, Admin")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderServiceAsync orderServiceAsync;
        private readonly MessageQueue _messageQueue;

        public OrderController(IOrderServiceAsync orderServiceAsync)
        {
            this.orderServiceAsync = orderServiceAsync;
            _messageQueue = new MessageQueue("amqp://guest:guest@host.docker.internal:5672","Order Microservice");
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
            return Ok(await orderServiceAsync.CheckOrderStatus(id));
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
            var result = await orderServiceAsync.GetOrderById(id);
            result.Order_Status = "completed";
            var serializeOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
            var JsonString = JsonSerializer.Serialize(result, serializeOptions);
            await _messageQueue.AddMessageToQueueAsync(JsonString, "OrderExchange", "OrderQueue", "custom-routing-key");
            return Ok(await orderServiceAsync.OrderCompleted(id));
        }
        //UpdateOrder
        [HttpPut]
        public async Task<IActionResult> UpdateOrder(OrderRequestModel model,int id)
        {
            return Ok(await orderServiceAsync.UpdateOrder(model,id));
        }
        //GetOrderById
        [HttpGet]
        public async Task<IActionResult> GetOrderById(int id)
        {
            return Ok(await orderServiceAsync.GetOrderById(id));
        }

        [HttpGet]
        public async Task<IActionResult> GetQueue()
        {
            var result = await _messageQueue.ReadMessageFromQueueAsync("OrderExchange", "OrderQueue", "custom-routing-key");
            return Ok(result);
        }

    }
}
