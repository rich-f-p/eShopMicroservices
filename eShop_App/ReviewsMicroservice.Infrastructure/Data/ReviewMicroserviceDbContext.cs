using Microsoft.EntityFrameworkCore;
using ReviewsMicroservice.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewsMicroservice.Infrastructure.Data
{
    public class ReviewMicroserviceDbContext : DbContext
    {
        public ReviewMicroserviceDbContext(DbContextOptions<ReviewMicroserviceDbContext> options) : base(options)
        {
        }
        public DbSet<Customer_Review> Customer_Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer_Review>()
                .Property(x => x.AdminApproval)
                .HasDefaultValue("UnderReview");
        }
    }
}
