using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvc.Models;
using mvc.Util;
using System.IO;
using System.Data.Entity;
using mvc.Filters;



namespace mvc.Controllers
{
    [Authorize(Users = "anton2222222222222@gmail.com")]
    public class HomeController : Controller
    {

        private BookContext db = new BookContext();


        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }



        public ActionResult GetBook(int? Id)
        {
            if(Id == null)
            {
                return HttpNotFound();
            }

            Book book = db.Books.Include(b => b.Author).
                FirstOrDefault(b => b.Id == Id);

            if (book == null)
                return HttpNotFound();

            return View("Book", book);
        }

        public ActionResult GetAuthor(int? Id)
        {
            if(Id == null){
                return HttpNotFound();
            }

            Book book = db.Books.Include(b => b.Author)
                .FirstOrDefault(b => b.Id == Id);

            if (book == null)
                return HttpNotFound();

            return View("Author", book.Author);

        }


        [Route("{id:int}/{name}")]
        public string Test(int id, string name)
        {
            return id.ToString() + ". " + name;
        }
        [Authorize(Users = "antosha")]
        public ActionResult Logs()
        {
            LogContext logContext = new LogContext();


            return View(logContext.Visitors);
        }
            
        //[MyAuthFilter]
        [MyAuthorizeAttribute(Roles = "administrator, buh")]
        //[IndexException]
        [HandleError(ExceptionType = typeof(System.IndexOutOfRangeException), View = "Error")]
       // [Cache(Duration =60)]
        [WhiteSpaceAttribute]
        [LogAttribute]
        public ActionResult Index()
        {
            IEnumerable<Book> books = db.Books;
            ViewBag.Books = books;

            SelectList list = new SelectList(books, "Author", "Name");
            ViewBag.list = list;


            return View();
        }

        [HttpGet]
        public ActionResult EditBook(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Book curBook = db.Books.Find(id);

            if (curBook != null)
            {
                return View(curBook);
            }

            return HttpNotFound();
        }

        [HttpPost]

        public ActionResult EditBook(Book book)
        {
            db.Entry(book).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Create(Book book)
        {
            db.Books.Add(book);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            Book book = db.Books.Find(id);

            if(book == null)
            {
                return HttpNotFound();
            }

            return View(book);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = db.Books.Find(id);

            if (book == null)
            {
                return HttpNotFound();
            }

            db.Books.Remove(book);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult BookView(int id)
        {
            Book curBool = db.Books.Find(id);

            return View(curBool);

        }

        public ContentResult Square(int a = 10, int b = 5)
        {
            a = int.Parse(Request.Params["a"]);
            b = int.Parse(Request.Params["b"]);

            double s = a * b / 2.0;

            return Content("Площадь равна " + s);
        }

        [HttpGet]
        public ActionResult Buy(int id)
        {
            Book curBook =  db.Books.Find(id);
            
            if (curBook == null)
            {
                return Redirect("/Home/Index");
            }

            Purchase purchase = new Purchase();
            purchase.BookId = id;

            ViewBag.BookId = id;
            ViewBag.BookName = curBook.Name;

            return View(purchase);
        }

        [HttpPost]
        public ActionResult Buy(Purchase purchase)
        {
            Book curBook = db.Books.Find(purchase.BookId);

            if (curBook.Age > purchase.Age)
            {
                return new HttpUnauthorizedResult();
            }

            if (purchase.Address == null)
            {
                return new HtmlResult("Укажите адрес!");
            }

            purchase.Date = DateTime.Now;
            db.Purchases.Add(purchase);
            db.SaveChanges();
            
            return new HtmlResult("Спасибо, " + purchase.Person + ", за покупку");

        }

        public ActionResult Partial()
        {
            ViewBag.Massage = "Частичное представление";
            return PartialView();
        }
    }
}