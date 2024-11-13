using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderMicroservice.ApplicationCore.Contracts.Services;
using OrderMicroservice.Infrastructure.Services;

namespace OrderMicroservice.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class ShoppingCartItemController : ControllerBase
    {
        private readonly IShopping_Cart_ItemServiceAsync shoppingCartItemServiceAsync;

        public ShoppingCartItemController(IShopping_Cart_ItemServiceAsync shoppingCartItemServiceAsync)
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
