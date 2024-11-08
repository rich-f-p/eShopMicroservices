using Microsoft.EntityFrameworkCore;
using OrderMicroservice.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMicroservice.Infrastructure.Data
{
    public class OrderMicroDbContext : DbContext
    {
        public OrderMicroDbContext(DbContextOptions<OrderMicroDbContext> context):base(context)
        {
            
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Order_Details> Order_Details { get; set; }
        public DbSet<Payment_Type> Payment_Types { get; set; }
        public DbSet<Shopping_Cart_Item> Shopping_Cart_Items { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<User_Address> User_Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasMany(o => o.Details)
                .WithOne(o => o.Order)
                .HasForeignKey(o => o.Order_Id);
            modelBuilder.Entity<ShoppingCart>()
                .HasMany(s=>s.Items)
                .WithOne(o => o.ShoppingCart)
                .HasForeignKey(s => s.Cart_Id);
            modelBuilder.Entity<Address>()
                .HasOne(a => a.User_Address)
                .WithOne(a => a.Address)
                .HasForeignKey<User_Address>(a => a.Address_Id);

        }
    }
}
