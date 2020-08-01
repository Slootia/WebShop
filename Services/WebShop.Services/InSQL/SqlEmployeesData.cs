using System;
using System.Collections.Generic;
using WebShop.DAL.Context;
using WebShop.Domain.Entities;
using WebShop.Interfaces;

namespace WebShop.Services.InSQL
{
    public class SqlEmployeesData : IEmployeesData
    {
        private readonly WebShopDB _db;

        public SqlEmployeesData(WebShopDB db) => _db = db;

        public IEnumerable<Employee> Get() => _db.Employees;

        public Employee GetById(int id) => _db.Employees.Find(id);

        public int Add(Employee employee)
        {
            if (employee is null)
                throw new ArgumentNullException(nameof(employee));

            _db.Add(employee);
            return employee.Id;
        }

        public void Edit(Employee employee)
        {
            if (employee is null)
                throw new ArgumentNullException(nameof(employee));

            _db.Update(employee);
        }

        public bool Delete(int id)
        {
            var employee = GetById(id);
            if (employee is null)
                return false;

            _db.Remove(employee);
            return true;
        }

        public void SaveChanges() => _db.SaveChanges();
    }
}
