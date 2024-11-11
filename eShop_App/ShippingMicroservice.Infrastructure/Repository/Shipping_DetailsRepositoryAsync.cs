using Microsoft.EntityFrameworkCore;
using ShippingMicroservice.ApplicationCore.Contracts.Repository;
using ShippingMicroservice.ApplicationCore.Entities;
using ShippingMicroservice.ApplicationCore.Models.Response;
using ShippingMicroservice.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingMicroservice.Infrastructure.Repository
{
    public class Shipping_DetailsRepositoryAsync : BaseRepositoryAsync<Shipping_Details>, IShipping_DetailsRepositoryAsync
    {
        private readonly ShippingMicroserviceDbContext context;

        public Shipping_DetailsRepositoryAsync(ShippingMicroserviceDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Shipping_Details>> GetDetailsByShipper(int id)
        {
            return await context.Shipping_Details.Where(x=>x.Order_Id==id).ToListAsync();
        }
    }
}
