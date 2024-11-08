using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderMicroservice.Infrastructure.Services;

namespace OrderMicroservice.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ShoppingCartItemController : ControllerBase
    {
        private readonly Shopping_Cart_ItemServiceAsync shoppingCartItemServiceAsync;

        public ShoppingCartItemController(Shopping_Cart_ItemServiceAsync shoppingCartItemServiceAsync)
        {
            this.shoppingCartItemServiceAsync = shoppingCartItemServiceAsync;
        }
        //DeleteShoppingCartItemById
        [HttpDelete]
        public async Task<IActionResult> DeleteShoppingCartItemById(int id)
        {
            return Ok(await shoppingCartItemServiceAsync.DeleteShoppingCartItemById(id));
        }
    }
}
