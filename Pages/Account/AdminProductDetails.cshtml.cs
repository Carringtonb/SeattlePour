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
    public class AdminProductDetailsModel : PageModel
    {
        private IInventory _context;
        public AdminProductDetailsModel(IInventory context, ICart cart)
        {
            _context = context;
        }

        public Product product { get; set; }

        public async Task OnGet(int productId)
        {
            product = await _context.GetProductByID(productId);
        }

        public async Task<IActionResult> OnPostDeleteAsync(int ID)
        {

            await _context.DeleteProduct(ID);

            return RedirectToAction("Admin", "Account");
        }
    }
}
