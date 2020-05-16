using System;
using System.Threading.Tasks;
using EcomProject.Data;
using EcomProject.Models;
using EcomProject.Models.Services;
using EcomProject;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace EcomTest
{
    public class UnitTest1
    {
        [Fact]
        public void CanAddNameToProduct()
        {
            Product product = new Product();
            product.Name = "Potato";

            Assert.Equal("Potato", product.Name);
        }

        [Fact]
        public void CanAddSKUToProduct()
        {
            Product product = new Product();
            product.SKU = "Potato";

            Assert.Equal("Potato", product.SKU);
        }
        [Fact]
        public void CanAddPriceToProduct()
        {
            Product product = new Product();
            product.Price = 400;

            Assert.Equal(400, product.Price);
        }
        [Fact]
        public void CanAddColorToProduct()
        {
            Product product = new Product();
            product.Color = "Potato";

            Assert.Equal("Potato", product.Color);
        }

        [Fact]
        public void CanAddDescriptionToProduct()
        {
            Product product = new Product();
            product.Description = "Potato";

            Assert.Equal("Potato", product.Description);
        }

        [Fact]
        public void CanAddImageToProduct()
        {
            Product product = new Product();
            product.Image = "Potato";

            Assert.Equal("Potato", product.Image);
        }

        [Fact]
        public void CanAddFinishToProduct()
        {
            Product product = new Product();
            product.Finish = "Potato";

            Assert.Equal("Potato", product.Finish);
        }
        [Fact]
        public void CanAddMaterialToProduct()
        {
            Product product = new Product();
            product.Material = "Potato";

            Assert.Equal("Potato", product.Material);
        }
        [Fact]
        public void CanAddSizeToProduct()
        {
            Product product = new Product();
            product.Size = "Potato";

            Assert.Equal("Potato", product.Size);
        }

        [Fact]
        public async Task CanAddProductToDB()
        {

            // Arrange
            DbContextOptions<ProductDbContext> options = new DbContextOptionsBuilder<ProductDbContext>()
                .UseInMemoryDatabase("CanAddPostToDB")
                .Options;

            // open the connection to the database
            using (ProductDbContext context = new ProductDbContext(options))
            {
                InventoryServices inventoryServices = new InventoryServices(context);

                Product product = new Product()
                {
                    Name = "This is our Test Name",
                    Description = "Let's see if this works! YAYY!"
                };

                var result = await inventoryServices.CreateProduct(product);

                // Check if the post exists through the context directly
                var data = context.Product.Find(product.ID);
                Assert.Equal(result, data);

                // change our service to have a return and check the data that came back
                Assert.Equal("This is our Test Name", product.Name);

            }

        }
    }
}
