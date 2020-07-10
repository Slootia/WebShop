using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration;
using WebShop.Infrastructure.Interfaces;
using WebShop.Models;
using WebShop.ViewModels;

namespace WebShop.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeesData _employeesData;

        public EmployeesController(IEmployeesData employeesData) =>
            _employeesData = employeesData;
        
        public IActionResult Index() => View(_employeesData.Get().Select(employee => new EmployeesViewModel
        {
            Id = employee.Id,
            FirstName = employee.Name,
            LastName = employee.Surname,
            Patronymic = employee.Patronymic,
            Age = employee.Age,
            EmployementDate = employee.EmployementDate
        }));

        public IActionResult Details(int id)
        {
            var employee = _employeesData.GetById(id);
            if (employee is null)
                return NotFound();

            return View(new EmployeesViewModel
            {
                Id = employee.Id,
                FirstName = employee.Name,
                LastName = employee.Surname,
                Patronymic = employee.Patronymic,
                Age = employee.Age,
                EmployementDate = employee.EmployementDate
            });
        }

        #region Edit
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
                Age = employee.Age,
                EmployementDate = employee.EmployementDate
            });
        }

        [HttpPost]
        public IActionResult Edit(EmployeesViewModel model)
        {
            if (model is null)
                throw new ArgumentNullException();

            if (!ModelState.IsValid)
                return View(model);

            var employee = new Employee
            {
                Id = model.Id,
                Surname = model.LastName,
                Name = model.FirstName,
                Patronymic = model.Patronymic,
                Age = model.Age,
                EmployementDate = model.EmployementDate
            };

            if (model.Id == 0)
                _employeesData.Add(employee);
            else
                _employeesData.Edit(employee);

            _employeesData.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Delete
        public IActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest();

            var employee = _employeesData.GetById(id);
            if (employee is null)
                return NotFound();

            return View(new EmployeesViewModel
            {
                Id = employee.Id,
                FirstName = employee.Name,
                LastName = employee.Surname,
                Patronymic = employee.Patronymic,
                Age = employee.Age,
                EmployementDate = employee.EmployementDate
            });
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            _employeesData.Delete(id);
            _employeesData.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        #endregion
    }
}
