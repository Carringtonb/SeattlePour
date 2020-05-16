using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthorizeNet.Api.Contracts.V1;
using AuthorizeNet.Api.Controllers;
using AuthorizeNet.Api.Controllers.Bases;
using EcomProject.Models;
using EcomProject.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace EcomProject.Pages.Account
{
    public class CheckoutModel : PageModel
    {

        private ICart _cart;
        private readonly UserManager<ApplicationUser> _userManager;
        public IEnumerable<CartItems> CartItems { get; set; }
        private IConfiguration _config;
        private IEmailSender _email;
        private IOrder _order;
        //public IList<OrderDetails> OrderDetails { get; set; }



        public CheckoutModel(ICart cart, UserManager<ApplicationUser> userManager, IConfiguration configuration, IEmailSender emailSender, IOrder order)
        {
            _cart = cart;
            _userManager = userManager;
            _config = configuration;
            _email = emailSender;
            _order = order;
        }

       
        public async Task<IActionResult> OnGet()
        {
            ApplicationUser user = await _userManager.GetUserAsync(User);
            CartItems = await _cart.GetAllCartItems(user.Id);

            decimal total = 0;
            foreach (var item in CartItems)
            {
                decimal price = item.Quantity * item.Product.Price;

                total += price;
            }

            decimal shipTotal = total + 32;
            string email = user.Email;
            TempData["Email"] = email;
            TempData["ShipTotal"] = shipTotal;

            if (user == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return Page();

        }

        public async Task<IActionResult> OnPost()
        {
            string EmailInput = Request.Form["Email"];
            string Address = Request.Form["Address"];
            string FirstName = Request.Form["FirstName"];
            string LastName = Request.Form["LastName"];
            string City = Request.Form["City"];
            string State = Request.Form["State"];
            string Zip = Request.Form["Zip"];
            DateTime Time = DateTime.Now;

            ApiOperationBase<ANetApiRequest, ANetApiResponse>.RunEnvironment = AuthorizeNet.Environment.SANDBOX;

            ApiOperationBase<ANetApiRequest, ANetApiResponse>.MerchantAuthentication = new merchantAuthenticationType()
            {
                name = _config["ApiLoginID"],
                ItemElementName = ItemChoiceType.transactionKey,
                Item = _config["TransactionKey"]
            };

            ApplicationUser user = await _userManager.GetUserAsync(User);
            CartItems = await _cart.GetAllCartItems(user.Id);


            decimal total = 0;

            foreach (var item in CartItems)
            {
                decimal price = item.Quantity * item.Product.Price;
                total += price;
            }

            total += 32;

            Order order = new Order()
            {
                FirstName = FirstName,
                LastName = LastName,
                UserID = EmailInput,
                Address = Address,
                City = City,
                Zip = Zip,
                State = State,
                TotalPrice = total,
                Time = DateTime.Now.ToString()
            };

            await _order.AddNewOrder(order);

            IList<OrderDetails> OrderDetails = new List<OrderDetails>();

            foreach (var item in CartItems)
            {
                OrderDetails orderDetail = new OrderDetails()
                {
                    OrderID = order.ID,
                    ProductID = item.Product.ID,
                    Quantity = item.Quantity
                };

                OrderDetails.Add(orderDetail);
            }

            foreach (var item in OrderDetails)
            {
                await _order.AddOrderItem(item);
            }


            var creditCard = new creditCardType
            {
                cardNumber = "4111111111111111",
                expirationDate = "1022",
                cardCode = "777"
            };

            customerAddressType address = new customerAddressType
            {
                firstName = FirstName,
                lastName = LastName,
                address = Address,
                city = City,
                zip = Zip,
                state = State,
                email = EmailInput,
               
            };

            var paymentType = new paymentType { Item = creditCard };

            var transaction = new transactionRequestType
            {
                transactionType = transactionTypeEnum.authCaptureTransaction.ToString(),
                amount = total,
                payment = paymentType,
                billTo = address
            };

            var request = new createTransactionRequest { transactionRequest = transaction };

            var controller = new createTransactionController(request);

            controller.Execute();

            var response = controller.GetApiResponse();

            if (response != null)
            {
                if (response.messages.resultCode == messageTypeEnum.Ok)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("<h1> Thank You for your order!</h1>");
                    sb.AppendLine("<p> This is a list of items purchased </p>");
                    foreach (var item in CartItems)
                    {
                        sb.AppendLine($"<p>{item.Product.Name} Quantity: {item.Quantity}. </p>");
                    }
                    sb.AppendLine("<p> Hope to see you again soon! </p>");


                    await _email.SendEmailAsync($"{user.Email}", "The Seattle Pour - Your orders have been submitted!", sb.ToString());


                    await _cart.RemoveAllCartItems(CartItems);
                    return RedirectToAction("Receipt", "Store");

                }
            }

            await _cart.RemoveAllCartItems(CartItems);
            return RedirectToAction("Receipt", "Store");

        }
    
    }
}
