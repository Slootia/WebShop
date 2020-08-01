using System.Collections.Generic;
using System.Linq;
using WebShop.Domain.Entities;
using WebShop.Domain.ViewModels;

namespace WebShop.Interfaces.Mapping
{
    public static class EmployeeMapper
    {
        public static EmployeesViewModel ToView(this Employee employee) => new EmployeesViewModel
        {
            Id = employee.Id,
            FirstName = employee.Name,
            LastName = employee.Surname,
            Patronymic = employee.Patronymic,
            Age = employee.Age,
            EmployementDate = employee.EmployementDate
        };

        public static IEnumerable<EmployeesViewModel> ToView(this IEnumerable<Employee> employees) =>
            employees.Select(ToView);

        public static Employee FromView(this EmployeesViewModel model) => new Employee
        {
            Id = model.Id,
            Surname = model.LastName,
            Name = model.FirstName,
            Patronymic = model.Patronymic,
            Age = model.Age,
            EmployementDate = model.EmployementDate
        };
    }
}
