using Microsoft.EntityFrameworkCore;
using OrderApi.Data;
using OrderApi.Models;

namespace OrderApi.Services
{
    public class OrderService : IOrderService
    {
        private readonly OrderContext _context;
        public OrderService(OrderContext context) {
            _context = context;
        }
        public async Task<IEnumerable<Order>> GetOrders() {
            return await _context.Orders.ToListAsync();
        }
        public async Task<Order> GetOrderById(int id)
        {
            return await _context.Orders.FindAsync(id);
        }
        public async Task<Order> CreateOrder(Order order) {
            if(String.IsNullOrEmpty(order.LastName) || String.IsNullOrEmpty(order.FirstName))
            {
                throw new ArgumentException("LastName and Description are mandatory.");
            }
            if (order.Quantity < 1 || order.Quantity > 20) { 
                throw new ArgumentException("Quantity must be between 1 and 20."); 
            }
            if (order.FirstName != null && order.FirstName.Length > 20)
            {
                throw new ArgumentException("FirstName cannot be longer than 20 characters.");
            }

            if (order.LastName.Length > 20)
            {
                throw new ArgumentException("LastName cannot be longer than 20 characters.");
            }

            if (order.Description?.Length > 100)
            {
                throw new ArgumentException("Description cannot be longer than 100 characters.");
            }

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }
        
        public async Task<bool> DeleteOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if(order == null)
            {
                return false;
            }
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return true;

        }
    }
}
