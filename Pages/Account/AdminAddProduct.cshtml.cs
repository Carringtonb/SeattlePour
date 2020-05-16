using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcomProject.Models;
using EcomProject.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EcomProject.Pages.Account
{
    [Authorize(Policy = "AdminOnly")]
    public class AdminAddProductModel : PageModel
    {
        private IInventory _inventory;

        public AdminAddProductModel(IInventory inventory)
        {
            _inventory = inventory;
        }


        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            string newSKU = Request.Form["SKU"];
            string newName = Request.Form["Name"];
            decimal newPrice = Convert.ToInt32(Request.Form["Price"]);
            string newDescription = Request.Form["Description"];
            string newImage = Request.Form["Image"];
            string newSize = Request.Form["Size"];
            string newColor = Request.Form["Color"];
            string newFinish = Request.Form["Finish"];
            string newMaterial = Request.Form["Material"];

            Product product = new Product();

            product.Name = newName;
            product.Size = newSize;
            product.SKU = newSKU;
            product.Price = newPrice;
            product.Description = newDescription;
            product.Image = newImage;
            product.Color = newColor;
            product.Finish = newFinish;
            product.Material = newMaterial;

            await _inventory.CreateProduct(product);

           return RedirectToAction("Admin", "Account");

        }
    }
}
