using System;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using EcomProject.Models.Interfaces;
using EcomProject.Models;
using Microsoft.AspNetCore.Identity;

namespace EcomProject.Controllers
{
    public class HomeController : Controller
    {
        // Brings in connection to database
        private IInventory _inventory;
        private readonly UserManager<ApplicationUser> _userManager;


        public HomeController(IInventory inventory, UserManager<ApplicationUser> userManager)
        {
            _inventory = inventory;
            _userManager = userManager;
        }
        /// <summary>
        /// Displays two random inventory items on the page as 'featured'
        /// </summary>
        /// <returns>Two featured inventory items</returns>
        public async Task<IActionResult> Index()
        {
            ApplicationUser user = await _userManager.GetUserAsync(User);

            if (user != null)
            { 
                string email = user.Email;
                TempData["Email"] = email;
            }



            int RandomNumber(int min, int max)
            {
                Random random = new Random();
                return random.Next(min, max);
            }

            
            var result = await _inventory.GetProductByID(RandomNumber(1, 11));
            var result1 = await _inventory.GetProductByID(RandomNumber(1, 11));
            if(result == result1)
            {
                result1 = await _inventory.GetProductByID(RandomNumber(1, 11));
            }

            List<Product> featured = new List<Product>();
            featured.Add(result);
            featured.Add(result1);

            return View(featured);
        }

       
    }
}
