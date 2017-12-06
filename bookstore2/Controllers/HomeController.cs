using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bookstore2.Models;

namespace bookstore2.Controllers
{
    public class HomeController : Controller
    {
        BookContext db = new BookContext();


        public ActionResult Index()
        {
            var firstbook = db.Books.FirstOrDefault();
            
            return View(firstbook);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}