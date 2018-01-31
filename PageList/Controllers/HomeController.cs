using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PageList.Models;
using PagedList.Mvc;
using PagedList;

namespace PageList.Controllers
{
    public class HomeController : Controller
    {
        List<Phone> phones;

        public HomeController()
        {
            phones = new List<Phone>();
            phones.Add(new Phone { Id = 1, Name = "Samsung Galaxi" });
            phones.Add(new Phone { Id = 2, Name = "Samsung Galaxi II" });
            phones.Add(new Phone { Id = 3, Name = "Samsung Galaxi II" });
            phones.Add(new Phone { Id = 4, Name = "Samsung ACE" });
            phones.Add(new Phone { Id = 5, Name = "Samsung ACE II" });
            phones.Add(new Phone { Id = 6, Name = "HTC One S" });
            phones.Add(new Phone { Id = 7, Name = "HTC One X" });
            phones.Add(new Phone { Id = 8, Name = "Nokia N9" });
            phones.Add(new Phone { Id = 5, Name = "Samsung ACE II" });
            phones.Add(new Phone { Id = 6, Name = "HTC One S" });
            phones.Add(new Phone { Id = 7, Name = "HTC One X" });
            phones.Add(new Phone { Id = 8, Name = "Nokia N9" });
            phones.Add(new Phone { Id = 5, Name = "Samsung ACE II" });
            phones.Add(new Phone { Id = 6, Name = "HTC One S" });
            phones.Add(new Phone { Id = 7, Name = "HTC One X" });
            phones.Add(new Phone { Id = 8, Name = "Nokia N9" });
        }

        public ActionResult Index(int? page)
        {
            int pageSize = 5;
            int pageNumber = (page ?? 1);

            return View(phones.ToPagedList(pageNumber, pageSize));
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