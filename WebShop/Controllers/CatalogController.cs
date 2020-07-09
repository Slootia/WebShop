using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebShop.Domain;
using WebShop.Infrastructure.Interfaces;
using WebShop.ViewModels;

namespace WebShop.Controllers
{
    public class CatalogController : Controller
    {
        private readonly IProductData _productData;

        public CatalogController(IProductData productData) => _productData = productData;

        public IActionResult Shop(ProductFilter filter)
        {
            var products = _productData.GetProducts(filter);

            return View(new CatalogViewModel()
            {
                SectionId = filter.SectionId,
                BrandId = filter.BrandId,
                Products = products.Select(p => new ProductViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Order = p.Order,
                    ImageUrl = p.ImageUrl,
                    Price = p.Price
                }).OrderBy(p => p.Order)
            });
        }
    }
}
