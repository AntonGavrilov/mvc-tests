using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace JQueryUI_1.Models
{
    public class Computer
    {
        public int Id { get; set; }

        [Display(Name ="Модель")]
        [Required]
        [MaxLength(20, ErrorMessage ="Превышена допустимая длина строки")]
        public string Model { get; set; }

        [Display(Name ="Год выпуска")]
        [Required]
        [Range(1970, 2014, ErrorMessage = "Недопустимый год")]
        public int Year { get; set; }
    }
}