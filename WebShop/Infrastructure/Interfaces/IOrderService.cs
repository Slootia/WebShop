using System.Collections.Generic;
using System.Threading.Tasks;
using WebShop.Domain.Entities.Orders;
using WebShop.ViewModels;

namespace WebShop.Infrastructure.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetUserOrders(string UserName);

        Task<Order> GetOrderById(int id);

        Task<Order> CreateOrder(string UserName, CartViewModel Cart, OrderViewModel OrderModel);
    }
}