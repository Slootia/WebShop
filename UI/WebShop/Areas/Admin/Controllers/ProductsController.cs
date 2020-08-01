using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Operations;
using WebShop.Domain.Entities;
using WebShop.Domain.Identity;
using WebShop.Infrastructure.Interfaces;

namespace WebShop.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Roles = Role.Administrator)]
    public class ProductsController : Controller
    {
        private readonly IProductData _productData;

        public ProductsController(IProductData productData) => _productData = productData;
        public IActionResult Index() => View(_productData.GetProducts());

        public IActionResult Edit(int id)
        {
            var product = _productData.GetProductById(id);
            if (product is null)
                return NotFound();
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
                return View(product);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var product = _productData.GetProductById(id);
            if (product is null)
                return NotFound();
            return View(product);
        }

        [HttpPost]
        public IActionResult DeleteConfirm(Product product)
        {
            return RedirectToAction(nameof(Index));
        }
    }
}
