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
    public class PaymentMethodRepositoryAsync : BaseRepositoryAsync<PaymentMethod>, IPaymentMethodRepositoryAsync
    {
        private readonly OrderMicroDbContext context;

        public PaymentMethodRepositoryAsync(OrderMicroDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<PaymentMethod> GetPaymentMethodByCustomerIdAsync(int id)
        {
            return await context.PaymentMethods.Include(p=>p.Payment_Type)
                .FirstOrDefaultAsync(x=>x.CustomerId==id);
        }
    }
}
