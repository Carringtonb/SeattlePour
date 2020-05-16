using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcomProject.Data;
using EcomProject.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EcomProject.Models.Services
{
    public class OrderServices : IOrder
    {
        private readonly ProductDbContext _context;

        public OrderServices(ProductDbContext context)
        {
            _context = context;
        }

        public async Task AddNewOrder(Order order)
        {
            await _context.Order.AddAsync(order);
            await _context.SaveChangesAsync();
        }

        public async Task AddOrderItem(OrderDetails orderDetails)
        {
            await _context.OrderDetails.AddAsync(orderDetails);
            await _context.SaveChangesAsync();
        }

        public async Task<Order> GetRecentOrders(string username)
        {
            var orders = await GetOrdersByUserId(username);
            return orders.OrderByDescending(order => order.ID).FirstOrDefault();
        }


        public async Task<List<Order>> GetOrdersByUserId(string username) => await _context.Order.Where(order => order.UserID == username).ToListAsync();



        public async Task<List<Order>> GetOrders() => await _context.Order.ToListAsync();



        public async Task<List<OrderDetails>> GetOrderDetails() => await _context.OrderDetails.Include(x => x.Product).ToListAsync();

    


        public async Task<List<OrderDetails>> GetOrderIdForUser(int orderId) => await _context.OrderDetails.Where(orderDetails => orderDetails.OrderID == orderId)
                                                                                                            .Include(x => x.Product)
                                                                                                            .Include(x => x.Order)
                                                                                                            .ToListAsync();





   
    }
}
