using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace mvc.Models
{
    public class Book
    {
        [HiddenInput (DisplayValue = false)]
        public int Id { get; set; }
        [Display(Name = "Название")]
        [UIHint("Url")]
        public string Name { get; set; }
        [Display(Name = "Автор")]
        public Author Author { get; set; }
        [Display(Name = "Цена" )]
        public int Price { get; set; }

        public int Age { get; set; }

        public int AuthorId { get; set; }
    }
}