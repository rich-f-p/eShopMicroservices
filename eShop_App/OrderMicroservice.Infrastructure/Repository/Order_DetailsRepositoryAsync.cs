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
    public class Order_DetailsRepositoryAsync : BaseRepositoryAsync<Order_Details>, IOrder_DetailsRepositoryAsync
    {
        private readonly OrderMicroDbContext context;

        public Order_DetailsRepositoryAsync(OrderMicroDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Order_Details>> GetDetailsByOrderId(int id)
        {
            return await context.Order_Details.Where(x => x.Order_Id == id).ToListAsync();
        }
    }
}
