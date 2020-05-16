using System;
using System.Threading.Tasks;
using EcomProject.Data;
using EcomProject.Models;
using EcomProject.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EcomProject.Components
{
    public class MiniCart : ViewComponent
    {
        private ICart _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public MiniCart(ICart context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }


        public async Task<IViewComponentResult> InvokeAsync(int number)
        {

            var userId = _userManager.GetUserId((System.Security.Claims.ClaimsPrincipal)User);
            var cartItems = await _context.GetCartIdForUser(userId);

            return View(cartItems);
        }
    }
}
