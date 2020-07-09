using System.Collections.Generic;
using WebShop.Domain.Entities;
using WebShop.Infrastructure.Data;
using WebShop.Infrastructure.Interfaces;

namespace WebShop.Infrastructure.Services
{
    public class InMemoryProductData : IProductData
    {
        public IEnumerable<Section> GetSections()
            => TestData.Sections;

        public IEnumerable<Brand> GetBrands()
            => TestData.Brands;
    }
}
