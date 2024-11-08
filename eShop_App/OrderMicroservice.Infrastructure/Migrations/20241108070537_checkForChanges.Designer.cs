﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OrderMicroservice.Infrastructure.Data;

#nullable disable

namespace OrderMicroservice.Infrastructure.Migrations
{
    [DbContext(typeof(OrderMicroDbContext))]
    [Migration("20241108070537_checkForChanges")]
    partial class checkForChanges
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("OrderMicroservice.ApplicationCore.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("varchar(56)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("varchar(52)");

                    b.Property<string>("Street1")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Street2")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("varchar(5)");

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("OrderMicroservice.ApplicationCore.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.Property<string>("Profile_PIC")
                        .IsRequired()
                        .HasColumnType("varchar(300)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("OrderMicroservice.ApplicationCore.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("BillAmount")
                        .HasColumnType("decimal(5, 2)");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("Order_Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Order_Status")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<int>("PaymentMethodId")
                        .HasColumnType("int");

                    b.Property<string>("PaymentName")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("ShippingAddress")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("ShippingMethod")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("OrderMicroservice.ApplicationCore.Entities.Order_Details", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Discount")
                        .HasColumnType("int");

                    b.Property<int>("Order_Id")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("Product_Id")
                        .HasColumnType("int");

                    b.Property<string>("Product_Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<int>("Qty")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Order_Id");

                    b.ToTable("Order_Details");
                });

            modelBuilder.Entity("OrderMicroservice.ApplicationCore.Entities.PaymentMethod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AccountNumber")
                        .IsRequired()
                        .HasColumnType("varchar(17)");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("Expiry")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<bool>("IsDefault")
                        .HasColumnType("bit");

                    b.Property<int?>("Payment_TypeId")
                        .HasColumnType("int");

                    b.Property<int>("Payment_Type_Id")
                        .HasColumnType("int");

                    b.Property<string>("Provider")
                        .IsRequired()
                        .HasColumnType("varchar(60)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("Payment_TypeId");

                    b.ToTable("PaymentMethods");
                });

            modelBuilder.Entity("OrderMicroservice.ApplicationCore.Entities.Payment_Type", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Payment_Types");
                });

            modelBuilder.Entity("OrderMicroservice.ApplicationCore.Entities.ShoppingCart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("ShoppingCarts");
                });

            modelBuilder.Entity("OrderMicroservice.ApplicationCore.Entities.Shopping_Cart_Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Cart_Id")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(5,2)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<int>("Qty")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Cart_Id");

                    b.ToTable("Shopping_Cart_Items");
                });

            modelBuilder.Entity("OrderMicroservice.ApplicationCore.Entities.User_Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Address_Id")
                        .HasColumnType("int");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("Customer_Id")
                        .HasColumnType("int");

                    b.Property<bool>("IsDefaultAddress")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("Address_Id")
                        .IsUnique();

                    b.HasIndex("CustomerId");

                    b.ToTable("User_Addresses");
                });

            modelBuilder.Entity("OrderMicroservice.ApplicationCore.Entities.Order_Details", b =>
                {
                    b.HasOne("OrderMicroservice.ApplicationCore.Entities.Order", "Order")
                        .WithMany("Details")
                        .HasForeignKey("Order_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("OrderMicroservice.ApplicationCore.Entities.PaymentMethod", b =>
                {
                    b.HasOne("OrderMicroservice.ApplicationCore.Entities.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OrderMicroservice.ApplicationCore.Entities.Payment_Type", "Payment_Type")
                        .WithMany("PaymentMethod")
                        .HasForeignKey("Payment_TypeId");

                    b.Navigation("Customer");

                    b.Navigation("Payment_Type");
                });

            modelBuilder.Entity("OrderMicroservice.ApplicationCore.Entities.Shopping_Cart_Item", b =>
                {
                    b.HasOne("OrderMicroservice.ApplicationCore.Entities.ShoppingCart", "ShoppingCart")
                        .WithMany("Items")
                        .HasForeignKey("Cart_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ShoppingCart");
                });

            modelBuilder.Entity("OrderMicroservice.ApplicationCore.Entities.User_Address", b =>
                {
                    b.HasOne("OrderMicroservice.ApplicationCore.Entities.Address", "Address")
                        .WithOne("User_Address")
                        .HasForeignKey("OrderMicroservice.ApplicationCore.Entities.User_Address", "Address_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OrderMicroservice.ApplicationCore.Entities.Customer", "Customer")
                        .WithMany("User_Address")
                        .HasForeignKey("CustomerId");

                    b.Navigation("Address");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("OrderMicroservice.ApplicationCore.Entities.Address", b =>
                {
                    b.Navigation("User_Address")
                        .IsRequired();
                });

            modelBuilder.Entity("OrderMicroservice.ApplicationCore.Entities.Customer", b =>
                {
                    b.Navigation("User_Address");
                });

            modelBuilder.Entity("OrderMicroservice.ApplicationCore.Entities.Order", b =>
                {
                    b.Navigation("Details");
                });

            modelBuilder.Entity("OrderMicroservice.ApplicationCore.Entities.Payment_Type", b =>
                {
                    b.Navigation("PaymentMethod");
                });

            modelBuilder.Entity("OrderMicroservice.ApplicationCore.Entities.ShoppingCart", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
