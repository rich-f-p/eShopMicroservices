using Microsoft.EntityFrameworkCore;
using ShippingMicroservice.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingMicroservice.Infrastructure.Data
{
    public class ShippingMicroserviceDbContext : DbContext
    {
        public ShippingMicroserviceDbContext(DbContextOptions<ShippingMicroserviceDbContext> options) : base(options)
        {
        }
        public DbSet<Region> Regions {  get; set; }
        public DbSet<Shipper> Shippers { get; set; }
        public DbSet<Shipper_Region> Shippers_Region { get; set; }
        public DbSet<Shipping_Details> Shipping_Details { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Shipping_Details>()
                .Property(x => x.Shipping_Status)
                .HasDefaultValue("Order starting");
            modelBuilder.Entity<Shipper_Region>()
                .HasKey(x => new { x.Region_Id, x.Shipper_Id });
        }
    }
}
