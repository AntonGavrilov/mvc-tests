using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using bookstore2.Annotations;

namespace bookstore2.Models
{    
    public class Book1
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        //[Required(ErrorMessage = "Заполните название книги")]
        //[StringLength(50, MinimumLength =3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]        
        [Display(Name = "Название")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Автор")]
        [MyAuthor("Пушкин", ErrorMessage = "Не допустимый автор")]
        public string Author { get; set; }
        [Required]
        [Range(1700, 2017, ErrorMessage = "Недопустимый год")]
        [Display(Name = "Год")]
        public int Year { get; set; }

    }
}