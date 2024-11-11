using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShippingMicroservice.ApplicationCore.Contracts.Repository;
using ShippingMicroservice.ApplicationCore.Contracts.Services;
using ShippingMicroservice.ApplicationCore.Models.Request;

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
