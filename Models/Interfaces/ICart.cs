using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EcomProject.Models.Interfaces
{
    public interface ICart
    {

        //Create
        Task CreateCartAsync(string userID);

        Task CreateCartItemAsync(CartItems cartItems);

        Task AddItemToCart(CartItems cartItems);

        //Read
        Task<Cart> GetCartIdForUser(string username);

        Task<CartItems> GetCartItemByProductIdForUserID(string username, int productId);

        Task<CartItems> GetSingleItem(int productID);

        Task<IEnumerable<CartItems>> GetAllCartItems(string username);

        Task<int> GetCartIdForUserInt(string username);

        //Update
        Task UpdateCartItemAsync(CartItems cartItems);

        //Delete
        Task RemoveCartItemsAsync(string username, int productId);

        Task RemoveAllCartItems(IEnumerable<CartItems> cartItems);
    }
}
