using Microsoft.EntityFrameworkCore;
using PromotionsMicroservice.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionsMicroservice.Infrastructure.Data
{
    public class PromotionMicroserviceDbContext : DbContext
    {
        public PromotionMicroserviceDbContext(DbContextOptions<PromotionMicroserviceDbContext> context) : base(context)
        {
        }
        public DbSet<PromotionSale> Promotion {  get; set; }
        public DbSet<Promotion_Details> PromotionDetails { get; set; }

    }
}
