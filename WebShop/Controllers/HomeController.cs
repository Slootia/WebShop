using Microsoft.AspNetCore.Mvc;

namespace WebShop.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
