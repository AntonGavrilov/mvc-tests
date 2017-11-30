using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvc.Models;


namespace mvc.Controllers
{
    public class TestController : Controller
    {
        // GET: Test

        [HttpPost]
        public string Index(string[] Books)
        {

            var result = "";

            foreach (var item in Books)
            {
                result += result == "" ? item : String.Concat(",", item);
            }

            return String.Concat("Вы выбрали ", result);
        }


        [HttpGet]
        public ViewResult Index()
        {
            BookContext context = new BookContext();

            SelectList list = new SelectList(context.Books, "Name", "Name");
            ViewBag.BookList = list;

            return View("Test");

        }

        public string test1()
        {
            var val = Session["name"];

            return val.ToString();
        }
    }
}