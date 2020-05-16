using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcomProject.Models;
using EcomProject.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EcomProject.Pages.Store
{
    // Logged in Users only 
    [Authorize]
    public class CartModel : PageModel
    {
        private ICart _cart;
        private readonly UserManager<ApplicationUser> _userManager;

        private IEmailSender _email;
        public IEnumerable<CartItems> CartItems { get; set; }

        public CartModel(ICart cart, UserManager<ApplicationUser> userManager, IEmailSender email)
        {
            _cart = cart;
            _userManager = userManager;
            _email = email;
        }


        public async Task<IActionResult> OnGet()
        {
            ApplicationUser user = await _userManager.GetUserAsync(User);
            CartItems = await _cart.GetAllCartItems(user.Id);

            string email = user.Email;
            TempData["Email"] = email;

            if (user == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {

            return RedirectToAction("Checkout", "Account");
        }

        public async Task<IActionResult> OnPostUpdateAsync(int id)
        {
            int newQuantity = Convert.ToInt32(Request.Form["Quantity"]);

            ApplicationUser user = await _userManager.GetUserAsync(User);
            CartItems cartItem = await _cart.GetCartItemByProductIdForUserID(user.Id, id);

            cartItem.Quantity = newQuantity;
            await _cart.UpdateCartItemAsync(cartItem);

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int ID)
        {
            ApplicationUser user = await _userManager.GetUserAsync(User);

            await _cart.RemoveCartItemsAsync(user.Id, ID);

            return RedirectToPage();
        }
    }
}
