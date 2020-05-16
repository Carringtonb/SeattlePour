using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcomProject.Data;
using EcomProject.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EcomProject.Models.Services
{
    public class CartServices : ICart
    {
        private ProductDbContext _context;
        private UserManager<ApplicationUser> _userManager;

        public CartServices(ProductDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;

        }

        public async Task CreateCartAsync(string userID)
        {
            Cart cart = new Cart();
            cart.UserID = userID;
            _context.Cart.Add(cart);
            await _context.SaveChangesAsync();
        }

        public async Task CreateCartItemAsync(CartItems cartItems)
        {
            await _context.CartItems.AddAsync(cartItems);
            await _context.SaveChangesAsync();
        }

        public async Task<Cart> GetCartIdForUser(string userId) => await _context.Cart.FirstOrDefaultAsync(cart => cart.UserID == userId);

        public async Task<int> GetCartIdForUserInt(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            var cart = await _context.Cart.FirstOrDefaultAsync(x => x.UserID == user.Id);
            if (cart != null)
            {
                return cart.ID;
            }

            return 0;
        }

        public async Task AddItemToCart(CartItems cartItems)
        {
            _context.CartItems.Add(cartItems);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CartItems>> GetAllCartItems(string username)
        {

            Cart cart = await GetCartIdForUser(username);
            return _context.CartItems.Where(cartItem => cartItem.CartID == cart.ID).Include(x => x.Product);
        }


        public async Task<CartItems> GetSingleItem(int productID) => await _context.CartItems.FindAsync(productID);

        public async Task<CartItems> GetCartItemByProductIdForUserID(string username, int productId)
        {
            var cartItems = await GetAllCartItems(username);
            return cartItems.FirstOrDefault(cart => cart.Product.ID == productId);
        }

        public async Task RemoveCartItemsAsync(string username, int productId)
        {

            CartItems cartItem = await GetCartItemByProductIdForUserID(username, productId);
            _context.CartItems.Remove(cartItem);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAllCartItems(IEnumerable<CartItems> cartItems)
        {
            _context.CartItems.RemoveRange(cartItems);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCartItemAsync(CartItems cartItems)
        {
            _context.CartItems.Update(cartItems);
            await _context.SaveChangesAsync();

        }


    }
}
