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
    public class AdminOrderDetailsModel : PageModel
    {
        private readonly IOrder _order;

        public AdminOrderDetailsModel(IOrder order)
        {
            _order = order;
        }

        public List<OrderDetails> OrderDetails { get; set; }
        public List<Order> Orders { get; set; }
        

        public async Task OnGetAsync(int id)
        {
            OrderDetails = await _order.GetOrderIdForUser(id);

            

            string custFirstName = "";
            string custLastName = "";
            string time = "";
            decimal price = 0;


            foreach (var item in OrderDetails)
            {
                custFirstName = item.Order.FirstName;
                custLastName = item.Order.LastName;
                time = item.Order.Time;
                price = item.Order.TotalPrice;
            }

            TempData["FirstName"] = custFirstName;
            TempData["LastName"] = custLastName;
            TempData["Time"] = time;
            TempData["Price"] = price;
        }
    }
}
