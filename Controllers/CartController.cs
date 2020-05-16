using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EcomProject.Models;
using EcomProject.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EcomProject.Controllers 
{
    [Route("/cart")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICart _cart;

        public CartController(ICart cart)
        {
            _cart = cart;

        }

        //[HttpPost]
        //public async Task<ActionResult<Cart>> CreateCartAsync(Cart cart)
        //{
        //    await _cart.CreateCartAsync(cart);
        //    return CreatedAtAction("CreateCart", new { id = cart.ID }, cart);
        //}
        //TODO Instantiate a cart for each user when they register
        //TODO when user clicks add to cart, queries cart items table to find the matching productID and and assign it to the users ID

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Cart>>> GetCartItemByUserIDAsync(int userID)
        //{
        //    return await _cart.GetCartByUserIDAsync(userID);
        //}

    }
}
