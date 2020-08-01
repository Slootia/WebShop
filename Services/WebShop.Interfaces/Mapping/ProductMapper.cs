using System.Collections.Generic;
using System.Linq;
using WebShop.Domain.Entities;
using WebShop.Domain.ViewModels;

namespace WebShop.Interfaces.Mapping
{
    public static class ProductMapper
    {
        public static ProductViewModel ToView(this Product p) => new ProductViewModel
        {
            Id = p.Id,
            Name = p.Name,
            Order = p.Order,
            ImageUrl = p.ImageUrl,
            Price = p.Price,
            Brand = p.Brand?.Name
        };

        public static IEnumerable<ProductViewModel> ToView(this IEnumerable<Product> products) =>
            products.Select(ToView);
    }
}
