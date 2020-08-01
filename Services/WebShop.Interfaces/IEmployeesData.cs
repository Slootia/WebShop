using System.Collections.Generic;
using WebShop.Domain.Entities;

namespace WebShop.Interfaces
{
    public interface IEmployeesData
    {
        IEnumerable<Employee> Get();

        Employee GetById(int id);

        int Add(Employee employee);

        void Edit(Employee employee);

        bool Delete(int id);

        void SaveChanges();
    }
}
