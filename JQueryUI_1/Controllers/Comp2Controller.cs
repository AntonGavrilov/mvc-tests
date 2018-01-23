using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JQueryUI_1.Models;
using System.Data.Entity;

namespace JQueryUI_1.Controllers
{
    public class Comp2Controller : Controller
    {
        static List<Computer> comps = new List<Computer>();
        // GET: Comp2
        public ActionResult Index()
        {
            return View(comps);
        }

        public ActionResult Create()
        {
            return PartialView("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Computer comp)
        {

            if (ModelState.IsValid)
            {
                comps.Add(comp);
                return PartialView("Success");
            }
            
            return PartialView(comp);
        }

    }
}