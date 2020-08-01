using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebShop.DAL.Context;
using WebShop.Domain;
using WebShop.Domain.Entities;
using WebShop.Infrastructure.Interfaces;

namespace WebShop.Infrastructure.Services.InSQL
{
    public class SqlProductData : IProductData
    {
        private readonly WebShopDB _db;

        public SqlProductData(WebShopDB db) => _db = db;

        public IEnumerable<Section> GetSections() => _db.Sections;

        public IEnumerable<Brand> GetBrands() => _db.Brands;

        public IEnumerable<Product> GetProducts(ProductFilter filter = null)
        {
            IQueryable<Product> query = _db.Products
                .Include(p => p.Brand)
                .Include(p => p.Section);

            if (filter?.Ids?.Length > 0)
            {
                query = query.Where(product => filter.Ids.Contains(product.Id));
            }
            else
            {
                if (filter?.BrandId != null) query = query.Where(p => p.BrandId == filter.BrandId);

                if (filter?.SectionId != null) query = query.Where(p => p.SectionId == filter.SectionId);
            }

            return query;
        }

        public Product GetProductById(int id) =>
            _db.Products.Include(p => p.Brand)
                .Include(p => p.Section)
                .FirstOrDefault(p => p.Id == id);
    }
}
