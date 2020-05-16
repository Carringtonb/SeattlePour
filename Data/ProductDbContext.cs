using System;
using EcomProject.Models;
using Microsoft.EntityFrameworkCore;

namespace EcomProject.Data
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {

        }
        /// <summary>
        /// Creates the original database content.
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<OrderDetails>().HasKey(orderdetails => new { orderdetails.OrderID, orderdetails.ProductID });



            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ID = 1,
                    Name = "Coffee Mania",
                    SKU = "1001",
                    Price = 400,
                    Description = "Strong Finish with mixture of resin and Coffee ground.",
                    Image = "/images/Pour1.jpg",
                    Size = "Large",
                    Color = "Brown",
                    Finish = "Resin",
                    Material = "Wood"
                },
                new Product
                {
                    ID = 2,
                    Name = "Sun Rising",
                    SKU = "1002",
                    Price = 400,
                    Description = "Mixture of some ray of sun and hardwork.",
                    Image = "/images/Pour2.jpg",
                    Size = "Small",
                    Color = "Brown",
                    Finish = "Resin",
                    Material = "Metal"
                },
                new Product
                {
                    ID = 3,
                    Name = "Mine-ral",
                    SKU = "1003",
                    Price = 400,
                    Description = "We use high quality, Home-Mined mineral.",
                    Image = "/images/Pour3.jpg",
                    Size = "Large",
                    Color = "Brown",
                    Finish = "Resin",
                    Material = "Wood"
                },
                new Product
                {
                    ID = 4,
                    Name = "The Dawn",
                    SKU = "1004",
                    Price = 400,
                    Description = "We made it at Dawn.",
                    Image = "/images/Pour4.jpg",
                    Size = "Medium",
                    Color = "Brown",
                    Finish = "Matte",
                    Material = "Wood"
                },
                new Product
                {
                    ID = 5,
                    Name = "The Dusk",
                    SKU = "1005",
                    Price = 400,
                    Description = "We made it at Dusk.",
                    Image = "/images/Pour5.jpg",
                    Size = "Large",
                    Color = "Brown",
                    Finish = "Gloss",
                    Material = "Metal"
                },
                new Product
                {
                    ID = 6,
                    Name = "The Horizon",
                    SKU = "1006",
                    Price = 400,
                    Description = "Animal Crossing inspired.",
                    Image = "/images/Pour6.jpg",
                    Size = "Medium",
                    Color = "Brown",
                    Finish = "Matte",
                    Material = "Wood"
                },
                new Product
                {
                    ID = 7,
                    Name = "The Crow",
                    SKU = "1007",
                    Price = 400,
                    Description = "Dark like a flower in the darkness.",
                    Image = "/images/Pour7.jpg",
                    Size = "Small",
                    Color = "Brown",
                    Finish = "Gloss",
                    Material = "Metal"
                },
                new Product
                {
                    ID = 8,
                    Name = "The River",
                    SKU = "1008",
                    Price = 400,
                    Description = "Made it by a river.",
                    Image = "/images/Pour8.jpg",
                    Size = "Large",
                    Color = "Brown",
                    Finish = "Matte",
                    Material = "Wood"
                },
                new Product
                {
                    ID = 9,
                    Name = "The Mountain",
                    SKU = "1009",
                    Price = 400,
                    Description = "Inspired by beautiful mountains surrounding Seattle.",
                    Image = "/images/Pour9.jpg",
                    Size = "Small",
                    Color = "Brown",
                    Finish = "Gloss",
                    Material = "Metal"
                },
                new Product
                {
                    ID = 10,
                    Name = "The Valley",
                    SKU = "1010",
                    Price = 400,
                    Description = "Created in a valley.",
                    Image = "/images/Pour10.jpg",
                    Size = "Medium",
                    Color = "Brown",
                    Finish = "Matte",
                    Material = "Wood"
                }
                );
        }

        public DbSet<Product> Product { get; set; }

        public DbSet<Cart> Cart { get; set; }

        public DbSet<CartItems> CartItems { get; set; }

        public DbSet<Order> Order { get; set; }

        public DbSet<OrderDetails> OrderDetails { get; set; }
    }
}