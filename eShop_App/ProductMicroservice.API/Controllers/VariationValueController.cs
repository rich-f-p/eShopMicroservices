using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductMicroservice.ApplicationCore.Contracts.Service;
using ProductMicroservice.ApplicationCore.Models.Request;

namespace ProductMicroservice.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VariationValueController : ControllerBase
    {
        private readonly IVariationValueServiceAsync serviceAsync;

        public VariationValueController(IVariationValueServiceAsync serviceAsync)
        {
            this.serviceAsync = serviceAsync;
        }
        //save
        [HttpPost]
        public async Task<IActionResult> Save(Variation_ValueRequestModel model)
        {
            return Ok(await serviceAsync.save(model));
        }
        //GetVariationId
        [HttpGet]
        public async Task<IActionResult> GetVariationId(int id)
        {
            return Ok(await serviceAsync.GetVariationById(id));
        }
    }
}
