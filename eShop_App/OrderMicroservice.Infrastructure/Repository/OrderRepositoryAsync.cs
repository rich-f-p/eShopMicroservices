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
    public class OrderRepositoryAsync : BaseRepositoryAsync<Order>, IOrderRepositoryAsync
    {
        private readonly OrderMicroDbContext context;
        public OrderRepositoryAsync(OrderMicroDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<int> CancelOrder(int id)
        {
            var order = await context.Orders.FirstOrDefaultAsync(o => o.Id == id);
            if(order != null)
            {
                order.Order_Status = "Canceled";
            }
            return context.SaveChanges();
        }

        public async Task<IEnumerable<Order>> CheckOrderHistory(int customerId)
        {
            return await context.Orders.Where(o=>o.CustomerId == customerId).ToListAsync();
        }

        public async Task<string> CheckOrderStatus(int id)
        {
            var result = await context.Orders.FirstOrDefaultAsync(x => x.Id == id);
            return result.Order_Status;
        }


        public async Task<int> OrderCompleted(int id)
        {
            var order = await context.Orders.FirstOrDefaultAsync(o=>o.Id==id);
            if(order != null)
            {
                order.Order_Status = "Completed";
                return context.SaveChanges();
            }
            return 0;
        }
    }
}
