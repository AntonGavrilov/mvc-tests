using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace bookstore2.Models
{
    public class BookDbIntilizer : DropCreateDatabaseAlways<BookContext>
    {
        protected override void Seed(BookContext db)
        {
            db.Books.Add(new Book { Name = "Война и мир", Author = "Пушки", Year = 2010});
            db.Books.Add(new Book { Name = "Отцы и дети", Author = "Пушкин", Year = 1989});
            db.Books.Add(new Book { Name = "Чайка", Author = "Пушкин", Year = 1989 });
        }
    }
}