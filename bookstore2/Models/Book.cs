using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bookstore2.Annotations;
using System.ComponentModel.DataAnnotations;

namespace bookstore2.Models
{
    public class Book  
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }   
        [Display(Name = "Название")]
        public string Name { get; set; }
        [Display(Name = "Автор")]
        public string Author { get; set; }
        [Display(Name = "Год")]
        public int Year { get; set; }
    }
}