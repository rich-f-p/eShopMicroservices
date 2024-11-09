using Microsoft.EntityFrameworkCore;
using ProductMicroservice.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMicroservice.Infrastructure.Data
{
    public class ProductMicroserviceDbContext : DbContext
    {
        public ProductMicroserviceDbContext(DbContextOptions<ProductMicroserviceDbContext> context) : base(context)
        {
        }
        public DbSet<Category_Variation> Category_Variations { get; set; }
        public DbSet<Product> Products {  get; set; }
        public DbSet<Product_Category> product_Categories { get; set; }
        public DbSet<Product_Variation_Values> product_Variation_Values { get; set; }
        public DbSet<Variation_Value> Variation_Values { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product_Variation_Values>()
                .HasKey(x => new { x.Product_Id, x.Variation_Value_Id });
        }
    }
}
