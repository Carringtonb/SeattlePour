using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcomProject.Models;
using EcomProject.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EcomProject.Pages.Store
{
    public class ReceiptModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private IOrder _order;
        private List<OrderDetails> OrderDetails { get; set; }

        public ReceiptModel(UserManager<ApplicationUser> userManager,IOrder order)
        {
            _userManager = userManager;
            _order = order;
        }

        public async Task<IActionResult> OnGet()
        {
            ApplicationUser user = await _userManager.GetUserAsync(User);
            Order order = await _order.GetRecentOrders(user.Email);
            OrderDetails = await _order.GetOrderIdForUser(order.ID);
            string email = user.Email;

            TempData["Orders"] = OrderDetails;
            TempData["Email"] = email;
            return Page();
        }
    }
}
