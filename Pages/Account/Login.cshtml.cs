using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using EcomProject.Models;
using EcomProject.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace EcomProject.Pages.Account
{
    public class LoginModel : PageModel
    {
        private SignInManager<ApplicationUser> _signInManager;
        private IConfiguration _configuration { get; }

        [BindProperty]
        public LoginViewModel Input { get; set; }

        public LoginModel(SignInManager<ApplicationUser> signInManager, IConfiguration configuration)
        {
            _signInManager = signInManager;
            _configuration = configuration;
        }
       
        public void OnGet()
        {
        }
        /// <summary>
        /// Allows a user to log in with their stored credentials
        /// </summary>
        /// <returns>Catalogue page</returns>
        public async Task<IActionResult> OnPost()
        {
            if(ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(Input.Email, Input.Password, isPersistent: false, false);
                
                if (result.Succeeded)
                {
                    if (Input.Email.ToLower() == "carringtonbeard@live.com" || Input.Email.ToLower() == "teddy.damian@yahoo.com"
                       || Input.Email.ToLower() == "amanda@codefellows.com" || Input.Email.ToLower() == "rice.jonathanm@gmail.com"
                       || Input.Email.ToLower() == "brentshanahan@gmail.com")
                    {
                        return RedirectToAction("AdminDashboard", "Account");

                    }
                    else
                    {
                        return RedirectToAction("ShopCatalogue", "Store");

                    }
                }
                else
                {
                    ModelState.AddModelError("", "Your login failed. Please try again.");
                    return Page();
                }
            }
            return Page();
        }

    }
}
