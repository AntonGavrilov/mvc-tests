using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc.Areas.Store.Controllers
{
    public class HomeController : Controller
    {
        // GET: Store/Home
        public string Index()
        {
            return "mvc.Areas.Store.Controllers.Index";
        }
    }
}