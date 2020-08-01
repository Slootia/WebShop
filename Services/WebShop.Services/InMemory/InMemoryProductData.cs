using System.Collections.Generic;
using System.Linq;
using WebShop.Domain;
using WebShop.Domain.Entities;
using WebShop.Infrastructure.Data;
using WebShop.Infrastructure.Interfaces;

namespace WebShop.Infrastructure.Services.InMemory
{
    public class InMemoryProductData : IProductData
    {
        public IEnumerable<Section> GetSections()
            => TestData.Sections;

        public IEnumerable<Brand> GetBrands()
            => TestData.Brands;

        public IEnumerable<Product> GetProducts(ProductFilter filter = null)
        {
            var query = TestData.Products;

            if (filter?.SectionId != null)
                query = query.Where(product => product.SectionId == filter.SectionId).ToList();

            if (filter?.BrandId != null) query = query.Where(product => product.BrandId == filter.BrandId).ToList();

            return query;
        }

        public Product GetProductById(int id) => TestData.Products.FirstOrDefault(p => p.Id == id);
    }
}
