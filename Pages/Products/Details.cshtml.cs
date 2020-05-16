using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcomProject.Models;
using EcomProject.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EcomProject.Pages.Products
{
    public class DetailsModel : PageModel
    {
        private IInventory _context;
        private ICart _cart;
        
        private readonly UserManager<ApplicationUser> _userManager;

        public DetailsModel(IInventory context, ICart cart, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _cart = cart;
            _userManager = userManager;
        }

        public Product product { get; set; }
        public IEnumerable<CartItems> CartItems { get; set; }

     

        public async Task<IActionResult> OnGet(int productId)
        {
            product = await _context.GetProductByID(productId);
            ApplicationUser user = await _userManager.GetUserAsync(User);

            string email = user.Email;
            TempData["Email"] = email;

            if (user == null)
            {
                return RedirectToAction("Index", "Home");
            }

            CartItems = await _cart.GetAllCartItems(user.Id);

            TempData["CartItems"] = CartItems;

            return Page();
        }

        public async Task<IActionResult> OnPost(int productId, int qty = 1)
        {
            var user = User.Identity.Name;

            ApplicationUser username = await _userManager.GetUserAsync(User);

            CartItems cartItem = await _cart.GetCartItemByProductIdForUserID(username.Id, productId);

            string email = username.Email;
            TempData["Email"] = email;

            int cartId = await _cart.GetCartIdForUserInt(user);

            if (cartId > 0)
            {
                if (cartItem == null)
                {
                    CartItems cartitems = new CartItems();
                    cartitems.CartID = cartId;
                    cartitems.Quantity = qty;
                    cartitems.Product = await _context.GetProductByID(productId);

                    await _cart.AddItemToCart(cartitems);
                    product = cartitems.Product;
                }
                else
                {
                    cartItem.Quantity++;
                    await _cart.UpdateCartItemAsync(cartItem);
                }

                return RedirectToAction("Cart", "Store");
            }
            else
            {
                return RedirectToPage("Register");
            }
        }
    }
}
