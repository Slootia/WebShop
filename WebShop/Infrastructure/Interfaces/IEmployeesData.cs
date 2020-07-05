using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Models;

namespace WebShop.Infrastructure.Interfaces
{
    interface IEmployeesData
    {
        IEnumerable<Employee> Get();

        Employee GetById(int id);

        int Add(Employee employee);

        void Employee(Employee employee);

        bool Delete(int id);

        void SaveChanges();
    }
}
