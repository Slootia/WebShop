using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebShop.Infrastructure.Data;
using WebShop.Models;

namespace WebShop.Controllers
{
    public class EmployeesController : Controller
    {
        private static readonly List<Employee> _employees = TestData.Empolyees;
        public IActionResult Index() => View(_employees);

        public IActionResult Details(int id)
        {
            var employee = _employees.FirstOrDefault(e => e.Id == id);
            if (employee is null)
                return NotFound();

            return View(employee);
        }
    }
}
