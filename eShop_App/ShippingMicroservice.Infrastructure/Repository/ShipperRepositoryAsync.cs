using Microsoft.EntityFrameworkCore;
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
    public class ShipperRepositoryAsync : BaseRepositoryAsync<Shipper>, IShipperRepositoryAsync
    {
        private readonly ShippingMicroserviceDbContext context;

        public ShipperRepositoryAsync(ShippingMicroserviceDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Shipper>> GetShippersByRegion(string Region)
        {
            return await context.Shippers
                .Join(context.Shippers_Region,
                s => s.Id,
                sr => sr.Shipper_Id,
                (s, sr) => new { s, sr })
                .Join(context.Regions,
                sr => sr.sr.Region_Id,
                r => r.Id,
                (sr, r) => new { sr.s, sr.sr, r })
                .Where(x => x.r.Name == Region)
                .Select(x => x.s)
                .ToListAsync();
        }
    }
}
