using System.Collections.Generic;
using WebShop.Domain.Entities;

namespace WebShop.Infrastructure.Interfaces
{
    public interface IProductData
    {
        IEnumerable<Section> GetSections();

        IEnumerable<Brand> GetBrands();
    }
}
