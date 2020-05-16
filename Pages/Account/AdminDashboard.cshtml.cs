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

namespace EcomProject.Pages.Account
{
    [Authorize(Policy = "AdminOnly")]
    public class AdminDashboardModel : PageModel
    {

        private readonly UserManager<ApplicationUser> _userManager;

        private IOrder _order;


        public AdminDashboardModel(IOrder order, UserManager<ApplicationUser> userManager)
        {
            _order = order;
            _userManager = userManager;
        }

        public List<Order> Orders { get; set; }
        public List<OrderDetails> OrderDetails { get; set; }

        public async Task OnGetAsync()
        {
            Orders = await _order.GetOrders();
            OrderDetails = await _order.GetOrderDetails();
        }


    }
}
