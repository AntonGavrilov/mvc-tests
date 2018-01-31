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

        public ActionResult Index()
        {
            var model = repo.GetComputerList();

            if (model.Count > 0)
                ViewBag.Message = String.Format("В базе данных {0} объект", 2);

            return View(model);
            //View(repo.GetComputerList());
        }

        [HttpPost]
        public ActionResult Create(Computer c)
        {
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