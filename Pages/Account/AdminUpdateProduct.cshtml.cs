using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcomProject.Models;
using EcomProject.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EcomProject.Pages.Account
{
    public class AdminUpdateProductModel : PageModel
    {
        private IInventory _context;
        public AdminUpdateProductModel(IInventory context, ICart cart)
        {
            _context = context;
        }

        public Product product { get; set; }

        public async Task OnGet(int productId) => product = await _context.GetProductByID(productId);

        public async Task<IActionResult> OnPostUpdateAsync(int productID)
        {
            string newSKU = Request.Form["SKU"];
            string newName = Request.Form["Name"];
            decimal newPrice = Convert.ToDecimal(Request.Form["Price"]);
            string newDescription = Request.Form["Description"];
            string newImage = Request.Form["Image"];
            string newSize = Request.Form["Size"];
            string newColor = Request.Form["Color"];
            string newFinish = Request.Form["Finish"];
            string newMaterial = Request.Form["Material"];



            Product product = await _context.GetProductByID(productID);
            product.Name = newName;
            product.Size = newSize;
            product.SKU = newSKU;
            product.Price = newPrice;
            product.Description = newDescription;
            product.Image = newImage;
            product.Color = newColor;
            product.Finish = newFinish;
            product.Material = newMaterial;

            await _context.UpdateProduct(productID, product);

           
            return RedirectToAction("AdminProductDetails", "Account");
        }
    }
}
