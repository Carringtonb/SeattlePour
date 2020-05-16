using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EcomProject.Models.Interfaces
{
    public interface IOrder
    {

        Task AddNewOrder(Order order);
        Task AddOrderItem(OrderDetails orderDetails);
        Task<Order> GetRecentOrders(string username);
        Task<List<Order>> GetOrdersByUserId(string username);
        Task<List<Order>> GetOrders();
        Task<List<OrderDetails>> GetOrderDetails();
        Task<List<OrderDetails>> GetOrderIdForUser(int orderId);
    }
       
}
