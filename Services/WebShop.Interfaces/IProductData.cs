using System.Collections.Generic;
using WebShop.Domain;
using WebShop.Domain.Entities;

namespace WebShop.Interfaces
{
    public interface IProductData
    {
        IEnumerable<Section> GetSections();

        IEnumerable<Brand> GetBrands();

        IEnumerable<Product> GetProducts(ProductFilter filter = null);

        Product GetProductById(int id);
    }
}
