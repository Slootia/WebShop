using Microsoft.AspNetCore.Mvc;
using WebShop.Infrastructure.Interfaces;
using WebShop.ViewModels;

namespace WebShop.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeesData _employeesData;

        public EmployeesController(IEmployeesData employeesData) =>
            _employeesData = employeesData;
        
        public IActionResult Index() => View(_employeesData.Get());

        public IActionResult Details(int id)
        {
            var employee = _employeesData.GetById(id);
            if (employee is null)
                return NotFound();

            return View(employee);
        }

        public IActionResult Edit(int? id)
        {
            if (id is null)
                return View(new EmployeesViewModel());
            if (id < 0)
            {
                return BadRequest();
            }

            var employee = _employeesData.GetById((int) id);
            if (employee is null)
                return NotFound();

            return View(new EmployeesViewModel
            {
                Id = employee.Id,
                FirstName = employee.Name,
                LastName = employee.Surname,
                Patronymic = employee.Patronymic,
                Age = employee.Age
            });
        }

        [HttpPost]
        public IActionResult Edit(EmployeesViewModel model)
        {
            return RedirectToAction(nameof(Index));
        }
    }
}
