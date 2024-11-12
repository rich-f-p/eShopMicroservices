//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using ShippingMicroservice.API.Models.Request;
//using System.Text;
//using System.Text.Json;

//namespace ShippingMicroservice.API.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ShippingUpdateController : ControllerBase
//    {
//        //method to update order status
//        [HttpGet]
//        public async Task<IActionResult> updateOrder(string model, int id)
//        {
//            HttpClient client = new HttpClient();
//            client.BaseAddress = new Uri("http://host.docker.internal:55446/api/");
//            var response = await client.GetAsync($"Order/GetOrderById?id={id}");
//            if (response.IsSuccessStatusCode)
//            {
//                var result = await response.Content.ReadFromJsonAsync<OrderRequestModel>();
//                result.Order_Status = model;//model.status
//                result.Id = id;
//                var serializeOptions = new JsonSerializerOptions
//                {
//                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
//                    WriteIndented = true
//                };
//                var JsonString = JsonSerializer.Serialize(result,serializeOptions);
//                var content = new StringContent(JsonString, Encoding.UTF8,"application/json");
//                response = await client.PutAsync($"Order/UpdateOrder?id={id}",content);
//                response.EnsureSuccessStatusCode();

//                return Ok(response);
//            }
//            return NotFound("Error shipping failed to update order!");  
//        }
//    }
//}
//  This is code that will get order by id and update that order 
