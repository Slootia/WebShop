using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebShop.Domain;
using WebShop.Domain.ViewModels;
using WebShop.Interfaces;
using WebShop.Interfaces.Mapping;

namespace WebShop.Controllers
{
    public class CatalogController : Controller
    {
        private readonly IProductData _productData;

        public CatalogController(IProductData productData) => _productData = productData;

        public IActionResult Shop(int? brandId, int? sectionId)
        {
            var filter = new ProductFilter
            {
                BrandId = brandId,
                SectionId = sectionId
            };

            var products = _productData.GetProducts(filter);

            return View(new CatalogViewModel()
            {
                SectionId = sectionId,
                BrandId = brandId,
                Products = products.ToView().OrderBy(p => p.Order)
            });
        }

        public IActionResult Details(int id)
        {
            var product = _productData.GetProductById(id);

            if (product is null)
                return NotFound();

            return View(product.ToView());
        }
    }
}
