using ShippingMicroservice.ApplicationCore.Contracts.Repository;
using ShippingMicroservice.ApplicationCore.Entities;
using ShippingMicroservice.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingMicroservice.Infrastructure.Repository
{
    public class Shipper_RegionRepositoryAsync : BaseRepositoryAsync<Shipper_Region>, IShipper_RegionRepositoryAsync
    {
        public Shipper_RegionRepositoryAsync(ShippingMicroserviceDbContext context) : base(context)
        {
        }
    }
}
