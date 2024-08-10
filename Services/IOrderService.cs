using OrderApi.Models;

namespace OrderApi.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetOrders();
        Task<Order> GetOrderById(int id);
        Task<Order> CreateOrder(Order order);
        Task<bool> DeleteOrder(int id);
    }
}
