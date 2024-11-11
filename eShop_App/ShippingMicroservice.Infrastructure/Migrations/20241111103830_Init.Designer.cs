﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShippingMicroservice.Infrastructure.Data;

#nullable disable

namespace ShippingMicroservice.Infrastructure.Migrations
{
    [DbContext(typeof(ShippingMicroserviceDbContext))]
    [Migration("20241111103830_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ShippingMicroservice.ApplicationCore.Entities.Region", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Regions");
                });

            modelBuilder.Entity("ShippingMicroservice.ApplicationCore.Entities.Shipper", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Contact_Person")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Shippers");
                });

            modelBuilder.Entity("ShippingMicroservice.ApplicationCore.Entities.Shipper_Region", b =>
                {
                    b.Property<int>("Region_Id")
                        .HasColumnType("int");

                    b.Property<int>("Shipper_Id")
                        .HasColumnType("int");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<int?>("RegionId")
                        .HasColumnType("int");

                    b.Property<int?>("ShipperId")
                        .HasColumnType("int");

                    b.HasKey("Region_Id", "Shipper_Id");

                    b.HasIndex("RegionId");

                    b.HasIndex("ShipperId");

                    b.ToTable("Shippers_Region");
                });

            modelBuilder.Entity("ShippingMicroservice.ApplicationCore.Entities.Shipping_Details", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Order_Id")
                        .HasColumnType("int");

                    b.Property<int?>("ShipperId")
                        .HasColumnType("int");

                    b.Property<int>("Shipping_Id")
                        .HasColumnType("int");

                    b.Property<string>("Shipping_Status")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("Order starting");

                    b.Property<string>("Tracking_Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ShipperId");

                    b.ToTable("Shipping_Details");
                });

            modelBuilder.Entity("ShippingMicroservice.ApplicationCore.Entities.Shipper_Region", b =>
                {
                    b.HasOne("ShippingMicroservice.ApplicationCore.Entities.Region", "Region")
                        .WithMany("Shippers")
                        .HasForeignKey("RegionId");

                    b.HasOne("ShippingMicroservice.ApplicationCore.Entities.Shipper", "Shipper")
                        .WithMany("Shipper_Region")
                        .HasForeignKey("ShipperId");

                    b.Navigation("Region");

                    b.Navigation("Shipper");
                });

            modelBuilder.Entity("ShippingMicroservice.ApplicationCore.Entities.Shipping_Details", b =>
                {
                    b.HasOne("ShippingMicroservice.ApplicationCore.Entities.Shipper", "Shipper")
                        .WithMany("Shipper_Details")
                        .HasForeignKey("ShipperId");

                    b.Navigation("Shipper");
                });

            modelBuilder.Entity("ShippingMicroservice.ApplicationCore.Entities.Region", b =>
                {
                    b.Navigation("Shippers");
                });

            modelBuilder.Entity("ShippingMicroservice.ApplicationCore.Entities.Shipper", b =>
                {
                    b.Navigation("Shipper_Details");

                    b.Navigation("Shipper_Region");
                });
#pragma warning restore 612, 618
        }
    }
}
