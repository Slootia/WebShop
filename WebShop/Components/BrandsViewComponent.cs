using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebShop.Infrastructure.Interfaces;
using WebShop.ViewModels;

namespace WebShop.Components
{
    public class BrandsViewComponent : ViewComponent
    {
        private readonly IProductData _productData;

        public BrandsViewComponent(IProductData productData) => _productData = productData;
        public IViewComponentResult Invoke() => View(GetBrands());

        private IEnumerable<BrandViewModel> GetBrands() =>
            _productData.GetBrands()
                .Select(brand => new BrandViewModel
                {
                    Id = brand.Id,
                    Name = brand.Name,
                    Order = brand.Order
                }).OrderBy(brand => brand.Order);
    }
}
