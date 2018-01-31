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

        [HttpPost]
        public void Edit()
        {

        }
        [HttpPost]
        public void Create(Book book)
        {

            var newBook = book;

            if (books.Count > 0)
            {
                newBook.Id = books.Max().Id + 1;
            }
            else
                newBook.Id = 1;


            books.Add(newBook);

        }
        [HttpPost]
        public void Delete(int id)
        {
            books.RemoveAll(b => b.Id == id);
        }
    }
}