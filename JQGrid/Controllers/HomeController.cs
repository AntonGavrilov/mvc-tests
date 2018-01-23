using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JQGrid.Models;
using Newtonsoft.Json;

namespace JQGrid.Controllers
{
    public class HomeController : Controller
    {
        static List<Book> books = new List<Book>();

        static HomeController()
        {
            books.Add(new Book { Id = 1, Author = "Толстой", Year = 1863, Price = 200, Name = "Война и мир" });
            books.Add(new Book { Id = 2, Author = "Тургенев", Year = 1863, Price = 200, Name = "Отцы и дети" });
            books.Add(new Book { Id = 3, Author = "Чехов", Year = 1863, Price = 200, Name = "Чайка" });
            books.Add(new Book { Id = 4, Author = "Достоевский", Year = 1863, Price = 200, Name = "Подросток" });

            books.Add(new Book { Id = 5, Author = "Достоевский", Year = 1863, Price = 200, Name = "Подросток" });
            books.Add(new Book { Id = 6, Author = "Достоевский", Year = 1863, Price = 200, Name = "Подросток" });
            books.Add(new Book { Id = 7, Author = "Достоевский", Year = 1863, Price = 200, Name = "Подросток" });
            books.Add(new Book { Id = 9, Author = "Достоевский", Year = 1863, Price = 200, Name = "Подросток" });
            books.Add(new Book { Id = 10, Author = "Достоевский", Year = 1863, Price = 200, Name = "Подросток" });
            books.Add(new Book { Id = 11, Author = "Достоевский", Year = 1863, Price = 200, Name = "Подросток" });
            books.Add(new Book { Id = 12, Author = "Достоевский", Year = 1863, Price = 200, Name = "Подросток" });
            books.Add(new Book { Id = 13, Author = "Достоевский", Year = 1863, Price = 200, Name = "Подросток" });
            books.Add(new Book { Id = 14, Author = "Достоевский", Year = 1863, Price = 200, Name = "Подросток" });
            books.Add(new Book { Id = 15, Author = "Достоевский", Year = 1863, Price = 200, Name = "Подросток" });

        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public string GetData()
        {
            return JsonConvert.SerializeObject(books);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}