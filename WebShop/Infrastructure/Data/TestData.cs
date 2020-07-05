using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Models;

namespace WebShop.Infrastructure.Data
{
    public static class TestData
    {
        public static List<Employee> Empolyees { get; } = new List<Employee>
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
    }
}
