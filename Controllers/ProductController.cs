using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EcomProject.Models;
using EcomProject.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EcomProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        //Brings in interface connection
        private readonly IInventory _inventory;

        public ProductController(IInventory inventory)
        {
            _inventory = inventory;

        }
        /// <summary>
        /// Add a new product to the inventory database
        /// </summary>
        /// <param name="product"></param>
        /// <returns>New product</returns>
        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(Product product)
        {
            await _inventory.CreateProduct(product);
            return CreatedAtAction("CreateProduct", new { id = product.ID }, product);
        }

        // GET: api/products
        // Get all products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return await _inventory.GetAllProducts();
        }
        

        // GET: api/products/{productID}
        // Get specific product by ID
        [HttpGet("{productID}")]
        public async Task<ActionResult<Product>> GetProductByID(int productID)
        {

            var product = await _inventory.GetProductByID(productID);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // DELETE: api/products/{id}
        // Delete specific product by entering ID
        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteProduct(int ID)
        {
            await _inventory.DeleteProduct(ID);

            return NoContent();
        }

        // PUT: api/product/{id}
        // update specific product by entering ID
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int ID, Product product)
        {
            if (ID != product.ID)
            {
                return BadRequest();
            }

            await _inventory.UpdateProduct(ID, product);

            return NoContent();
        }
    }
}
