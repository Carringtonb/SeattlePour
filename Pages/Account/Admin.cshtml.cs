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
    public class AdminModel : PageModel
    {
        private IInventory _inventory;

        public AdminModel(IInventory inventory)
        {
            _inventory = inventory;
        }
        public List<Product> Products { get; set; }

        public async Task OnGet()
        {
            Products = await _inventory.GetAllProducts();
        }

    }
}
