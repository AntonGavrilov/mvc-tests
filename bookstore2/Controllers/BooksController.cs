using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using bookstore2.Models;
using System.Threading;


namespace bookstore2.Controllers
{
    public class BooksController : Controller
    {
        private BookContext db = new BookContext();

        // GET: Books
        public ActionResult Index()
        {
            db.Configuration.ValidateOnSaveEnabled = false;
            return View(db.Books);
        }
 
        public JsonResult JsonSearch(String name)
        {
            Thread.Sleep(3000);
            var jsonData = db.Books.Where(a => a.Author.Contains(name)).ToList();
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CurBook(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return PartialView(book);
        }

        [HttpPost]
        public ActionResult BookSearch(string name)
        {
            Thread.Sleep(3000);

            var allbooks = db.Books.Where(a => a.Author.Contains(name)).ToList();
                
            if(allbooks.Count < 0)
            {
                return HttpNotFound();
            }

            return PartialView(allbooks);
        }



        public ActionResult BookSearchAjax(string name)
        {
            Thread.Sleep(3000);

            var allbooks = db.Books.Where(a => a.Author.Contains(name)).ToList();

            if (allbooks.Count < 0)
            {
                return HttpNotFound();
            }

            return PartialView(allbooks);
        }


        public ActionResult Search()
        {
            return View();
        }

        public ActionResult SearchAjax()
        {
            return View();
        }


        public string BrowserInfo(string browser)
        {
            return browser;
        }

        // GET: Books/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Author,Year")] Book book)
        {

            if (String.IsNullOrEmpty(book.Name))
            {                
                ModelState.AddModelError("Name", "Некоректное название книги");
            }


            if (ModelState.IsValid)
            {
                ViewBag.Message = "Valid";
                db.Books.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Message = "Not Valid";

            return View(book);
        }

        // GET: Books/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Author,Year")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(book);
        }

        // GET: Books/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = db.Books.Find(id);
            db.Books.Remove(book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
