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
    public class Shopping_Cart_ItemRepositoryAsync : BaseRepositoryAsync<Shopping_Cart_Item>, IShopping_Cart_ItemRepositoryAsync
    {
        private readonly OrderMicroDbContext context;

        public Shopping_Cart_ItemRepositoryAsync(OrderMicroDbContext context) : base(context)
        {
            this.context = context;
        }

    }
}
