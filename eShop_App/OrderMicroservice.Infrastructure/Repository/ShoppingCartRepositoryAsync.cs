using Microsoft.EntityFrameworkCore;
using OrderMicroservice.ApplicationCore.Contracts.Repository;
using OrderMicroservice.ApplicationCore.Entities;
using OrderMicroservice.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMicroservice.Infrastructure.Repository
{
    public class ShoppingCartRepositoryAsync : BaseRepositoryAsync<ShoppingCart>, IShoppingCartRepositoryAsync
    {
        private readonly OrderMicroDbContext context;

        public ShoppingCartRepositoryAsync(OrderMicroDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<ShoppingCart> GetShoppingCartByCustomerIdAsync(int id)
        {
            return await context.ShoppingCarts.Include(x => x.Items)
                .FirstOrDefaultAsync(x => x.CustomerId == id);
        }
    }
}
