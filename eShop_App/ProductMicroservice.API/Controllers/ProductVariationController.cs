using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductMicroservice.ApplicationCore.Contracts.Service;
using ProductMicroservice.ApplicationCore.Entities;
using ProductMicroservice.ApplicationCore.Models.Request;

namespace ProductMicroservice.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductVariationController : ControllerBase
    {
        private readonly IProductVariationServiceAsync serviceAsync;

        public ProductVariationController(IProductVariationServiceAsync serviceAsync)
        {
            this.serviceAsync = serviceAsync;
        }
        //save
        [HttpPost]
        public async Task<IActionResult> Save(Product_Variation_ValuesRequestModel model)
        {
            return Ok(await serviceAsync.Save(model));
        }
        //GetProductVariation
        [HttpGet]
        public async Task<IActionResult> GetProductVariation(int productId,int variationId)
        {
            return Ok(await serviceAsync.GetProductVariationById(productId,variationId));
        }
    }
}
