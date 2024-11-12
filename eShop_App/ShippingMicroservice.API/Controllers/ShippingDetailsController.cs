using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShippingMicroservice.ApplicationCore.Contracts.Repository;
using ShippingMicroservice.ApplicationCore.Contracts.Services;
using ShippingMicroservice.ApplicationCore.Models.Request;
using System.Text.Json;
using System.Text;
using ShippingMicroservice.API.Models.Request;

namespace ShippingMicroservice.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippingDetailsController : ControllerBase
    {
        private readonly IShippingDetailsServiceAsync detailsService;

        public ShippingDetailsController(IShippingDetailsServiceAsync detailsService)
        {
            this.detailsService = detailsService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await detailsService.GetAllDetails());
        }

        [HttpPost]
        public async Task<IActionResult> postDetail(Shipper_DetailsRequestModel model)
        {
            return Ok(await detailsService.SaveDetails(model));
        }

        [HttpPut]
        public async Task<IActionResult> update(Shipper_DetailsRequestModel model, int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://host.docker.internal:55446/api/");
            //get the existing order by id
            var response = await client.GetAsync($"Order/GetOrderById?id={model.Order_Id}");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<OrderRequestModel>();
                //update the status
                result.Order_Status = model.Shipping_Status;
                result.Id = model.Order_Id;
                var serializeOptions = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    WriteIndented = true
                };
                var JsonString = JsonSerializer.Serialize(result, serializeOptions);
                var content = new StringContent(JsonString, Encoding.UTF8, "application/json");
                response = await client.PutAsync($"Order/UpdateOrder?id={model.Order_Id}", content);
                response.EnsureSuccessStatusCode();
            }

            return Ok(await detailsService.UpdateDetails(model,id));
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await detailsService.GetDetailsById(id));
        }
        [HttpDelete]
        [Route("delete-{id}")]
        public async Task<IActionResult> delete(int id)
        {
            return Ok(await detailsService.DeleteDetails(id));
        }
        [HttpGet]
        [Route("Shipper/{id}")]
        public async Task<IActionResult> GetByShipper(int id)
        {
            return Ok(await detailsService.GetDetailsByShipper(id));
        }
    }
}
