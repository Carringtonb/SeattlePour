using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcomProject.Models;
using EcomProject.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EcomProject.Pages.Store
{

    public class ShopCatalogueModel : PageModel
    {
        private IInventory _inventory;
        private ICart _cart;
        private readonly UserManager<ApplicationUser> _userManager;

        public ShopCatalogueModel(IInventory inventory, UserManager<ApplicationUser> userManager, ICart cart)
        {
            _inventory = inventory;
            _userManager = userManager;
            _cart = cart;
        }

        public IEnumerable<CartItems> CartItems { get; set; }
        public List<Product> Products { get; set; }
        
        public async Task<IActionResult> OnGet()
        {
            Products = await _inventory.GetAllProducts();
            ApplicationUser user = await _userManager.GetUserAsync(User);

            if (user != null)
            {
                string email = user.Email;
                TempData["Email"] = email;
                CartItems = await _cart.GetAllCartItems(user.Id);
                TempData["CartItems"] = CartItems;
            }
            else
            {
                TempData["Email"] = null;
                TempData["CartItems"] = null;
            }


            
            

            return Page();

        }

    }
}
