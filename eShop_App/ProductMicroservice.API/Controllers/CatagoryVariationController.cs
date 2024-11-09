using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductMicroservice.ApplicationCore.Contracts.Service;
using ProductMicroservice.ApplicationCore.Models.Request;

namespace ProductMicroservice.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CatagoryVariationController : ControllerBase
    {
        private readonly ICategoryVariationServiceAsync serviceAsync;

        public CatagoryVariationController(ICategoryVariationServiceAsync serviceAsync)
        {
            this.serviceAsync = serviceAsync;
        }
        //Save
        [HttpPost]
        public async Task<IActionResult> Save(Category_VariationRequestModel model)
        {
            return Ok(await serviceAsync.Save(model));
        }
        //GetAll
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await serviceAsync.GetAll());
        }
        //GetCategoryVariationById
        [HttpGet]
        public async Task<IActionResult> GetCategoryVariationById(int id)
        {
            return Ok(await serviceAsync.GetCategoryVariationById(id));
        }
        //GetCategoryVariationByCategoryId
        [HttpGet]
        public async Task<IActionResult> GetCategoryVariationByCategoryId(int id)
        {
            return Ok(await serviceAsync.GetCategoryVariationByCategoryId(id));
        }
        //Delete
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await serviceAsync.Delete(id));
        }
    }
}
