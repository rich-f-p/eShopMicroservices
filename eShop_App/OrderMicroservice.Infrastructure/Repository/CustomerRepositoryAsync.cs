using Microsoft.EntityFrameworkCore;
using OrderMicroservice.ApplicationCore.Contracts.Repository;
using OrderMicroservice.ApplicationCore.Entities;
using OrderMicroservice.ApplicationCore.Models.Response;
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

        public async Task<List<Address>> GetCustomerAddressByUserIdAsync(int id)
        {
            var result = from c in context.Customers
                         join u in context.User_Addresses on c.Id equals u.Customer_Id
                         join a in context.Addresses on u.Address_Id equals a.Id
                         where c.UserId ==id
                         select a;
            return await result.ToListAsync();
                
        }
    }
}
