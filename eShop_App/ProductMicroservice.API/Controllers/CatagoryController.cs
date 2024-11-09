using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductMicroservice.ApplicationCore.Contracts.Service;
using ProductMicroservice.ApplicationCore.Models.Request;

namespace ProductMicroservice.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CatagoryController : ControllerBase
    {
        private readonly ICategoryServiceAsync serviceAsync;

        public CatagoryController(ICategoryServiceAsync serviceAsync)
        {
            this.serviceAsync = serviceAsync;
        }
        //SaveCategory
        [HttpPost]
        public async Task<IActionResult> SaveCategory(Product_CategoryRequestModel model)
        {
            return Ok(await serviceAsync.saveCategory(model));
        }
        //GetAllCategory
        [HttpGet]
        public async Task<IActionResult> GetAllCategory()
        {
            return Ok(await serviceAsync.GetAllCategory());
        }
        //GetCategoryById
        [HttpGet]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            return Ok(await serviceAsync.GetCategoryById(id));
        }
        //Delete
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await serviceAsync.Delete(id));
        }
        //GetCategoryByParentCategoryId
        [HttpGet]
        public async Task<IActionResult> GetCategoryByParentCategoryId(int id)
        {
            return Ok(await serviceAsync.GetCategoryByParentCategoryId(id));
        }
    }
}
