using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebShop.Domain.Identity;
using WebShop.ViewModels.Identity;

namespace WebShop.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Register() => View(new RegisterUserViewModel());

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Register(RegisterUserViewModel model)
        {
            if (ModelState.IsValid)
                return View(model);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Login() => View();
        public IActionResult Logout() => RedirectToAction("Index", "Home");
        public IActionResult AccessDenied() => View();
    }
}
