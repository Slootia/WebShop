﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebShop.Domain.Identity;

namespace WebShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = Role.Administrator)]
    public class HomeController : Controller
    {
        public IActionResult Index() => View();
    }
}
