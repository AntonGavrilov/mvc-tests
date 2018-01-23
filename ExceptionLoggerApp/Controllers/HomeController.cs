using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExceptionLoggerApp.Filters;

namespace ExceptionLoggerApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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
        [ExceptionLoggerAttribute]
        public ActionResult Test(int id)
        {
            if (id > 3)
            {
                int[] arr = new int[2];
                arr[6] = 4;

            }
            else if (id < 3)
            {
                throw new Exception("id не может быть меньше 3");
            }
            else
            {
                throw new Exception("Некорректное значение для параметра id");
            }

            return View();
        }

    }
}