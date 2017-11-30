using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace mvc.Models
{
    public class BookDbIntilizer : DropCreateDatabaseAlways<BookContext>
    {
        protected override void Seed(BookContext db)
        {
            db.Books.Add(new Book { Name = "Война и миров", Author = "Л.Толстой", Price = 200, Age = 21 });
            db.Books.Add(new Book { Name = "Отцы и дети", Author = "И.Тургенев", Price = 180, Age = 5 });
            db.Books.Add(new Book { Name = "Чайка", Author = "А.Чехов", Price = 150, Age = 5 });
        }
    }
}