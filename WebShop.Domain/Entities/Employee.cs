using System;
using WebShop.Domain.Entities.Base;

namespace WebShop.Domain.Entities
{
    public class Employee : NamedEntity
    {
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public int Age { get; set; }
        public DateTime EmployementDate { get; set; }
    }
}
