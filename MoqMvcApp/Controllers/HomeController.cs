using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MoqMvcApp.Models;

namespace MoqMvcApp.Controllers
{
    public class HomeController : Controller
    {
        IRepository repo;

        public HomeController(IRepository r)
        {
            repo = r;
        }

        public HomeController()
        {
            repo = new ComputerRepository();
        }

        public string Index()
        {

            List<string> events = HttpContext.Application["events"] as List<string>;

            var result = "<ul>";

            events.ForEach(e => result += "<li>" + e + "</li>");

            return result ;
        }

        [HttpPost]
        public ActionResult Create(Computer c)
        {

            if (c.Name.Length < 5)
                ModelState.AddModelError("Name", "Название должно быть больше 5");

            if (ModelState.IsValid)
            {
                repo.Create(c);
                repo.Save();
                return RedirectToAction("index");
            }

            return View("Create");
            
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

        protected override void Dispose(bool disposing)
        {
            repo.Dispose();
            base.Dispose(disposing);
        }
    }
}