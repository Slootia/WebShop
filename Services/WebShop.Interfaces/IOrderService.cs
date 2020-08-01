using System.Collections.Generic;
using System.Threading.Tasks;
using WebShop.Domain.Entities.Orders;
using WebShop.Domain.ViewModels;

namespace WebShop.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetUserOrders(string UserName);

        Task<Order> GetOrderById(int id);

        Task<Order> CreateOrder(string UserName, CartViewModel Cart, OrderViewModel OrderModel);
    }
}