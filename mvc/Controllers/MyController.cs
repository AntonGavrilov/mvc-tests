using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using mvc.Util;
using mvc.Models;

namespace mvc.Controllers
{
    public class MyController : Controller
    {
        BookContext db = new BookContext();

        public ActionResult Index()
        {

            return View("View1", db.Books);

        }

        public ActionResult GetHtml()
        {
            return new HtmlResult("<h2>Привет мир</h2>");
        }
    }
}