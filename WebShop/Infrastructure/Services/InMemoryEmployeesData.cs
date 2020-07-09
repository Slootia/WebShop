using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Infrastructure.Data;
using WebShop.Infrastructure.Interfaces;
using WebShop.Models;

namespace WebShop.Infrastructure.Services
{
    public class InMemoryEmployeesData : IEmployeesData
    {

        private static readonly List<Employee> _employees = 
            TestData.Empolyees;

        public IEnumerable<Employee> Get() => _employees;

        public Employee GetById(int id) => 
            _employees.FirstOrDefault(e => e.Id == id);

        public int Add(Employee employee)
        {
            if (employee is null)
                throw new ArgumentNullException(nameof(employee));

            if (_employees.Contains(employee))
                return employee.Id;

            employee.Id = _employees.Count == 0 ? 1 : _employees.Max(e => e.Id) + 1;
            _employees.Add(employee);

            return employee.Id;
        }

        public void Edit(Employee employee)
        {
            if (employee is null)
                throw new ArgumentNullException(nameof(employee));
            
            if (_employees.Contains(employee)) return;

            var dbEmployee = GetById(employee.Id);
            if (dbEmployee is null) return;

            dbEmployee.Name = employee.Name;
            dbEmployee.Surname = employee.Surname;
            dbEmployee.Patronymic = employee.Patronymic;
            dbEmployee.Age = employee.Age;

        }

        public bool Delete(int id) =>
            _employees.RemoveAll(e => e.Id == id) > 0;

        public void SaveChanges()
        {
        }
    }
}
