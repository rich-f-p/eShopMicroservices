using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShippingMicroservice.ApplicationCore.Contracts.Services;
using ShippingMicroservice.ApplicationCore.Models.Request;

namespace ShippingMicroservice.API.Controllers
{
    [Route("api/shipper")]
    [ApiController]
    public class ShippingController : ControllerBase
    {
        private readonly IShipperServicesAsync shipperService;

        public ShippingController(IShipperServicesAsync shipperService)
        {
            this.shipperService = shipperService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await shipperService.GetAllShipppers());
        }

        [HttpPost]
        public async Task<IActionResult> postShipper(ShipperRequestModel model)
        {
            return Ok(await shipperService.SaveShipper(model));
        }

        [HttpPut]
        public async Task<IActionResult> update(ShipperRequestModel model,int id)
        {
            return Ok(await shipperService.UpdateShippper(model,id));
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await shipperService.GetShipperById(id));
        }
        [HttpDelete]
        [Route("delete-{id}")]
        public async Task<IActionResult> delete(int id)
        {
            return Ok(await shipperService.DeleteShipper(id));
        }
        [HttpGet]
        [Route("region/{region}")]
        public async Task<IActionResult> GetByRegion(string region)
        {
            return Ok(await shipperService.GetShippersByRegion(region));
        }
    }
}
