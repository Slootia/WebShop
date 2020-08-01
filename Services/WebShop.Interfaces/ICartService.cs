using WebShop.Domain.ViewModels;

namespace WebShop.Interfaces
{
    public interface ICartService
    {
        void AddToCart(int id);

        void DecrementFromCart(int id);

        void RemoveFromCart(int id);

        void Clear();

        CartViewModel TransformFromCart();
    }
}
