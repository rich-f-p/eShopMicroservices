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
    public class Payment_TypeRepositoryAsync : BaseRepositoryAsync<Payment_Type>, IPayment_TypeRepositoryAsync
    {
        private readonly OrderMicroDbContext context;

        public Payment_TypeRepositoryAsync(OrderMicroDbContext context) : base(context)
        {
            this.context = context;
        }
    }
}
