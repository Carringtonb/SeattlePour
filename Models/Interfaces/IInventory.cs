using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EcomProject.Models.Interfaces
{
    public interface IInventory
    {
        Task<Product> CreateProduct(Product product);
        Task<List<Product>> GetAllProducts();
        Task<Product> GetProductByID(int ID);
        Task DeleteProduct(int ID);
        Task UpdateProduct(int ID, Product product);

    }
}
