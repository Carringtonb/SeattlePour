using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using EcomProject.Models;
using EcomProject.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace EcomProject.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private ICart _cart;
        private IEmailSender _email;
       

        [BindProperty]
        public RegisterInput RegisterData { get; set; }

        public RegisterModel(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signIn, ICart cart, IEmailSender email)
        {
            _userManager = userManager;
            _signInManager = signIn;
            _cart = cart;
            _email = email;
        }

        public void OnGet()
        {
        }
        /// <summary>
        /// Allows for the creation of a new user
        /// </summary>
        /// <returns>Catalogue page</returns>
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = RegisterData.Email,
                    Email = RegisterData.Email,
                    FirstName = RegisterData.FirstName,
                    LastName = RegisterData.LastName,
                };
                var result = await _userManager.CreateAsync(user, RegisterData.Password);

                if (result.Succeeded)
                {

                
                    Claim name = new Claim("FullName", $"{user.FirstName} {user.LastName}");
                    Claim email = new Claim(ClaimTypes.Email, user.Email, ClaimValueTypes.Email);

                    List<Claim> claims = new List<Claim>()
                    {
                        name, email
                    };

                    await _userManager.AddClaimsAsync(user, claims);


                    if (user.Email.ToLower() == "carringtonbeard@live.com" || user.Email.ToLower() == "teddy.damian@yahoo.com"
                       || user.Email.ToLower() == "amanda@codefellows.com" || user.Email.ToLower() == "rice.jonathanm@gmail.com"
                       || user.Email.ToLower() == "brentshanahan@gmail.com")
                    {
                        await _userManager.AddToRoleAsync(user, ApplicationRoles.Admin);
                        await _userManager.AddToRoleAsync(user, ApplicationRoles.Member);

                    }
                    else
                    {
                        await _userManager.AddToRoleAsync(user, ApplicationRoles.Member);

                    }



                    await _cart.CreateCartAsync(user.Id);

                

                    await _signInManager.SignInAsync(user, isPersistent: false);

                    // Email Sender
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("<h1> Thank You for registering</h1>");
                    sb.AppendLine("<p> Start Browsing </p>");
                    await _email.SendEmailAsync($"{user.Email}", "Registration Complete", sb.ToString());

                    // Redirect Depending on Role
                    if (user.Email == "carringtonbeard@live.com" || user.Email == "teddy.damian@yahoo.com"
                       || user.Email == "amanda@codefellows.com" || user.Email == "rice.jonathanm@gmail.com"
                       || user.Email == "Brentshanahan@gmail.com")
                    {
                        return RedirectToPage("/Account/Admin");
                    }

                        return RedirectToPage("/Store/ShopCatalogue");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return Page();
        }


    public class RegisterInput
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email Address")]
            public string Email { get; set; }

            [Required]
            [Display(Name ="First Name")]
            public string FirstName { get; set; }

            [Required]
            [Display(Name = "Last Name")]
            public string LastName { get; set; }

            [Required]
            [StringLength(69, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long", MinimumLength = 6)]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [Compare("Password", ErrorMessage ="The passwords do not match")]
            public string ConfirmPassword { get; set; }
        }
    }
}
