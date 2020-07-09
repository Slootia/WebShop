﻿using System.Linq;
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