using AutoMapper;
using OrderMicroservice.ApplicationCore.Contracts.Services;
using OrderMicroservice.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMicroservice.Infrastructure.Services
{
    public class Shopping_Cart_ItemServiceAsync : IShopping_Cart_ItemServiceAsync
    {
        private readonly Shopping_Cart_ItemRepositoryAsync shoppingCartItemRepo;

        public Shopping_Cart_ItemServiceAsync(Shopping_Cart_ItemRepositoryAsync shoppingCartItemRepo)
        {
            this.shoppingCartItemRepo = shoppingCartItemRepo;
        }
        public async Task<int> DeleteShoppingCartItemById(int id)
        {
            return await shoppingCartItemRepo.DeleteAsync(id);
        }
    }
}
