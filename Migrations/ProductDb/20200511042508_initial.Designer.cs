﻿// <auto-generated />
using System;
using EcomProject.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EcomProject.Migrations.ProductDb
{
    [DbContext(typeof(ProductDbContext))]
    [Migration("20200511042508_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EcomProject.Models.Cart", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("UserID")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Cart");
                });

            modelBuilder.Entity("EcomProject.Models.CartItems", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CartID")
                        .HasColumnType("int");

                    b.Property<int?>("ProductID")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CartID");

                    b.HasIndex("ProductID");

                    b.ToTable("CartItems");
                });

            modelBuilder.Entity("EcomProject.Models.Order", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Time")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("UserID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Zip")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("EcomProject.Models.OrderDetails", b =>
                {
                    b.Property<int>("OrderID")
                        .HasColumnType("int");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("OrderID", "ProductID");

                    b.HasIndex("ProductID");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("EcomProject.Models.Product", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Finish")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Material")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("SKU")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Size")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Product");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Color = "Brown",
                            Description = "Strong Finish with mixture of resin and Coffee ground.",
                            Finish = "Resin",
                            Image = "/images/Pour1.jpg",
                            Material = "Wood",
                            Name = "Coffee Mania",
                            Price = 400m,
                            SKU = "1001",
                            Size = "Large"
                        },
                        new
                        {
                            ID = 2,
                            Color = "Brown",
                            Description = "Mixture of some ray of sun and hardwork.",
                            Finish = "Resin",
                            Image = "/images/Pour2.jpg",
                            Material = "Metal",
                            Name = "Sun Rising",
                            Price = 400m,
                            SKU = "1002",
                            Size = "Small"
                        },
                        new
                        {
                            ID = 3,
                            Color = "Brown",
                            Description = "We use high quality, Home-Mined mineral.",
                            Finish = "Resin",
                            Image = "/images/Pour3.jpg",
                            Material = "Wood",
                            Name = "Mine-ral",
                            Price = 400m,
                            SKU = "1003",
                            Size = "Large"
                        },
                        new
                        {
                            ID = 4,
                            Color = "Brown",
                            Description = "We made it at Dawn.",
                            Finish = "Matte",
                            Image = "/images/Pour4.jpg",
                            Material = "Wood",
                            Name = "The Dawn",
                            Price = 400m,
                            SKU = "1004",
                            Size = "Medium"
                        },
                        new
                        {
                            ID = 5,
                            Color = "Brown",
                            Description = "We made it at Dusk.",
                            Finish = "Gloss",
                            Image = "/images/Pour5.jpg",
                            Material = "Metal",
                            Name = "The Dusk",
                            Price = 400m,
                            SKU = "1005",
                            Size = "Large"
                        },
                        new
                        {
                            ID = 6,
                            Color = "Brown",
                            Description = "Animal Crossing inspired.",
                            Finish = "Matte",
                            Image = "/images/Pour6.jpg",
                            Material = "Wood",
                            Name = "The Horizon",
                            Price = 400m,
                            SKU = "1006",
                            Size = "Medium"
                        },
                        new
                        {
                            ID = 7,
                            Color = "Brown",
                            Description = "Dark like a flower in the darkness.",
                            Finish = "Gloss",
                            Image = "/images/Pour7.jpg",
                            Material = "Metal",
                            Name = "The Crow",
                            Price = 400m,
                            SKU = "1007",
                            Size = "Small"
                        },
                        new
                        {
                            ID = 8,
                            Color = "Brown",
                            Description = "Made it by a river.",
                            Finish = "Matte",
                            Image = "/images/Pour8.jpg",
                            Material = "Wood",
                            Name = "The River",
                            Price = 400m,
                            SKU = "1008",
                            Size = "Large"
                        },
                        new
                        {
                            ID = 9,
                            Color = "Brown",
                            Description = "Inspired by beautiful mountains surrounding Seattle.",
                            Finish = "Gloss",
                            Image = "/images/Pour9.jpg",
                            Material = "Metal",
                            Name = "The Mountain",
                            Price = 400m,
                            SKU = "1009",
                            Size = "Small"
                        },
                        new
                        {
                            ID = 10,
                            Color = "Brown",
                            Description = "Created in a valley.",
                            Finish = "Matte",
                            Image = "/images/Pour10.jpg",
                            Material = "Wood",
                            Name = "The Valley",
                            Price = 400m,
                            SKU = "1010",
                            Size = "Medium"
                        });
                });

            modelBuilder.Entity("EcomProject.Models.CartItems", b =>
                {
                    b.HasOne("EcomProject.Models.Cart", null)
                        .WithMany("CartItems")
                        .HasForeignKey("CartID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EcomProject.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductID");
                });

            modelBuilder.Entity("EcomProject.Models.OrderDetails", b =>
                {
                    b.HasOne("EcomProject.Models.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EcomProject.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}