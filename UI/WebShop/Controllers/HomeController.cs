using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebShop.Interfaces;

namespace WebShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IValuesService _valuesService;

        public HomeController(IValuesService valuesService)
        {
            _valuesService = valuesService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _valuesService.GetAsync();
            return View(values);
        }

        public IActionResult Throw(string id) => 
            throw new ApplicationException($"Исключение: {id ?? "<null>"}");

        public IActionResult Blogs() => View();

        public IActionResult BlogSingle() => View();
        
        public IActionResult Checkout() => View();
        
        public IActionResult ContactUs() => View();

        public IActionResult Error404() => View();
    }
}
