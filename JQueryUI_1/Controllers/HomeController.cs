using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JQueryUI_1.Models;

namespace JQueryUI_1.Controllers
{
    public class HomeController : Controller
    {
        static List<Computer> comps = new List<Computer>();

        public ActionResult Index()
        {
            return View();
        }

        static HomeController()
        {
            comps.Add(new Computer { Id = 1, Model = "IBM PC", Year = 1981 });
            comps.Add(new Computer { Id = 2, Model = "Apple II", Year = 1977 });
            comps.Add(new Computer { Id = 3, Model = "Apple III", Year = 1980 });
            comps.Add(new Computer { Id = 4, Model = "Macintosh", Year = 1984 });
        }

        public ActionResult AutocompleteSearch(string term)
        {
            var models = comps.Where(m => m.Model.Contains(term))
                                        .Select(a => new { value = a.Model })
                                        .Distinct();
            return Json(models, JsonRequestBehavior.AllowGet);
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