using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using JQueryUI_1.Models;
using Newtonsoft.Json;
using System.Data.Entity;

namespace JQueryUI_1.Controllers
{
    public class CompController : Controller
    {
        CompContext db = new CompContext();

        public ActionResult Index()
        {
            return View(db.Computers);
        }

        public ActionResult Details(int id)
        {
            Computer comp = db.Computers.Find(id);

            if (comp != null)
            {
                return PartialView("Details", comp);
            }

            return View("Index");
        }

        [HttpGet]
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
                db.Computers.Add(comp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("Index");

        }

        public ActionResult Edit(int id)
        {
            Computer comp = db.Computers.Find(id);

            if(comp != null)
            {
                return PartialView("Edit", comp);
            }
            return View("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Computer comp)
        {
            db.Entry(comp).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index"); 
        }

        public ActionResult Delete(int id)
        {
            Computer comp = db.Computers.Find(id);

            if(comp != null)
            {
                return PartialView("Delete", comp);
            }
            return View("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteRecord(int id)
        {
            Computer comp = db.Computers.Find(id);

            if (comp != null)
            {
                db.Computers.Remove(comp);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }


    }
}
