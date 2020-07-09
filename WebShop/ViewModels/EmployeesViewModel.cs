using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace WebShop.ViewModels
{
    public class EmployeesViewModel
    {
        [HiddenInput(DisplayValue =  false)]
        public int Id { get; set; }

        [Display(Name = "Имя")]
        [Required(ErrorMessage = "Имя является обязательным полем")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Длина строки должна быть не более 200 и не менее 3")]
        [RegularExpression(@"([А-ЯЁ][а-яё]+)|([A-Z][a-z]+)", ErrorMessage = "Ошибка формата имени")]
        public string FirstName { get; set; }

        [Display(Name = "Фамилия")]
        [Required(ErrorMessage = "Фамилия является обязательным полем")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Длина строки должна быть не более 200 и не менее 3")]
        public string LastName { get; set; }

        [Display(Name = "Отчество")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Длина строки должна быть не более 200 и не менее 3")]
        public string Patronymic { get; set; }

        [Display(Name = "Возраст")]
        [Required(ErrorMessage = "Возраст является обязательным полем")]
        [Range(18, 80, ErrorMessage = "Возраст должен быть от 18 до 80")]
        public int Age { get; set; }

        [Display(Name = "Дата начала трудового договора")]
        [DataType(DataType.DateTime)]
        public DateTime EmployementDate { get; set; }
    }
}
