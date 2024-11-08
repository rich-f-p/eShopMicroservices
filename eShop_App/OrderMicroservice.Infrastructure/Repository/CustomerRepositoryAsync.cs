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
    public class CustomerRepositoryAsync : BaseRepositoryAsync<Customer>, ICustomerRepositoryAsync
    {
        private readonly OrderMicroDbContext context;

        public CustomerRepositoryAsync(OrderMicroDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<Customer> GetCustomerAddressByUserIdAsync(int id)
        {
            return await context.Customers
                .Include(u => u.User_Address)
                .ThenInclude(a => a.Address)
                .FirstOrDefaultAsync(c => c.UserId == id);
        }
    }
}
