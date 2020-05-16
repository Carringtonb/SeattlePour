using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcomProject.Data;
using EcomProject.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EcomProject.Models.Services
{
    public class InventoryServices : IInventory
    {
        private ProductDbContext _context;

        //Brings in connection to product database
        public InventoryServices(ProductDbContext context)
        {
            _context = context;

        }

        /// <summary>
        /// Creates a new product.
        /// </summary>
        /// <param name="product"></param>
        /// <returns>Newly created project</returns>
        public async Task<Product> CreateProduct(Product product)
        {
            _context.Add(product);
            await _context.SaveChangesAsync();

            return product;
        }

        /// <summary>
        /// Removes a product from the database
        /// </summary>
        /// <param name="ID"></param>
        /// <returns>N/A</returns>
        public async Task DeleteProduct(int ID)
        {
            Product product = await _context.Product.FindAsync(ID);
            _context.Product.Remove(product);
            await _context.SaveChangesAsync();
        }
        /// <summary>
        /// Grabs a list of all the products from thge database
        /// </summary>
        /// <returns>List of all products</returns>
        public async Task<List<Product>> GetAllProducts()
        {
            
         return await _context.Product.ToListAsync();
        }
        /// <summary>
        /// Gets one product from the inventory based on ID
        /// </summary>
        /// <param name="ID"></param>
        /// <returns>Single product</returns>
        public async Task<Product> GetProductByID(int ID)
        {

            Product product = await _context.Product.FindAsync(ID);
            return product;
        }
        /// <summary>
        /// Allows a products info to be edited
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="product"></param>
        /// <returns>Same product with new details</returns>
        public async Task UpdateProduct(int ID, Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }


    }
}
