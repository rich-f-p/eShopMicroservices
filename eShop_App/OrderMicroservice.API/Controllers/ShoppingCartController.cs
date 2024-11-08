﻿//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using OrderMicroservice.ApplicationCore.Models.Request;
//using OrderMicroservice.Infrastructure.Services;

//namespace OrderMicroservice.API.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ShoppingCartController : ControllerBase
//    {
//        private readonly ShoppingCartServiceAsync shoppingCartServiceAsync;

//        public ShoppingCartController(ShoppingCartServiceAsync shoppingCartServiceAsync)
//        {
//            this.shoppingCartServiceAsync = shoppingCartServiceAsync;
//        }
//        //GetShoppingCartByCustomerId
//        [HttpGet]
//        public async Task<IActionResult> GetShoppingCartByCustomerId(int id)
//        {
//            return Ok(await shoppingCartServiceAsync.GetShoppingCartByCustomerIdAsync(id));
//        }
//        //SaveShoppingCart
//        [HttpPost]
//        public async Task<IActionResult> SaveShoppingCart(ShoppingCartRequestModel cart)
//        {
//            return Ok(await shoppingCartServiceAsync.SaveShoppingCartAsync(cart));
//        }
//        //DeleteShoppingCart
//        [HttpDelete]
//        public async Task<IActionResult> DeleteShoppingCart(int id)
//        {
//            return Ok(await shoppingCartServiceAsync.DeleteShoppingCartAsync(id));
//        }
//    }
//}
