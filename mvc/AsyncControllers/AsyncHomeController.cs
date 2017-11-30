using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using mvc.Models;
using System.Data.Entity;

namespace mvc.AsyncControllers
{
    public class AsyncHomeController : Controller
    {
        BookContext db = new BookContext();


        // GET: AsyncHome
        public ActionResult Index()
        {
            IEnumerable<Book> books = db.Books;
            ViewBag.Books = books;

            return View("");
        }

        public async Task<ActionResult> BookList()
        {
            IEnumerable<Book> books = await db.Books.ToListAsync();
            ViewBag.Books = books;
            return View("AsyncIndex");
        }
    }
}