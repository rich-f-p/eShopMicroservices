using OrderMicroservice.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMicroservice.ApplicationCore.Contracts.Repository
{
    public interface IShoppingCartRepositoryAsync : IRepositoryAsync<ShoppingCart>
    {
        Task<ShoppingCart> GetShoppingCartByCustomerIdAsync(int id);
    }
}
