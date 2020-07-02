using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebShop.Models;

namespace WebShop.Controllers
{
    public class EmployeesController : Controller
    {
        private static readonly List<Employee> _employees = new List<Employee>
        {
            new Employee()
            {
                Id = 1,
                Surname = "Иванов",
                Name = "Иван",
                Patronymic = "Иванович",
                Age = 25
            },
            new Employee()
            {
                Id = 2,
                Surname = "Петров",
                Name = "Петр",
                Patronymic = "Петрович",
                Age = 52
            },
            new Employee()
            {
                Id = 3,
                Surname = "Сидоров",
                Name = "Алексей",
                Patronymic = "Семенович",
                Age = 23
            },
            new Employee()
            {
                Id = 4,
                Surname = "Основин",
                Name = "Александр",
                Patronymic = "Алексеевич",
                Age = 38
            }
        };


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
