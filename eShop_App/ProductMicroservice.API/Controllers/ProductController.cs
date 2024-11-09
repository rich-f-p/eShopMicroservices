using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductMicroservice.ApplicationCore.Contracts.Service;
using ProductMicroservice.ApplicationCore.Models.Request;

namespace ProductMicroservice.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServiceAsync serviceAsync;

        public ProductController(IProductServiceAsync serviceAsync)
        {
            this.serviceAsync = serviceAsync;
        }
        //GetListProducts
        [HttpGet]
        public async Task<IActionResult> GetListProducts()
        {
            return Ok(await serviceAsync.GetListProducts());
        }
        //GetProductById
        [HttpGet]
        public async Task<IActionResult> GetProductById(int id)
        {
            return Ok(await serviceAsync.GetProductById(id));
        }
        //Save
        [HttpPost]
        public async Task<IActionResult> Save(ProductRequestModel model)
        {
            return Ok(await serviceAsync.Save(model));
        }
        //Update
        [HttpPut]
        public async Task<IActionResult> Update(ProductRequestModel model,int id)
        {
            return Ok(await serviceAsync.Update(model,id));
        }
        //InActive
        [HttpPut]
        public async Task<IActionResult> InActive(int id)
        {
            return Ok(await serviceAsync.InActive(id));
        }
        //GetProductByCategoryId
        [HttpGet]
        public async Task<IActionResult> GetProductByCategoryId(int id)
        {
            return Ok(await serviceAsync.GetProductByCategoryId(id));
        }
        //GetProductByName
        [HttpGet]
        public async Task<IActionResult> GetProductByName(string name)
        {
            return Ok(await serviceAsync.GetProductByName(name));
        }
        //DeleteProduct
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            return Ok(await serviceAsync.DeleteProduct(id));
        }
    }
}
