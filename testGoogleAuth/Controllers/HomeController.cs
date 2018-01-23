using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading;
using System.Security.Claims;

namespace testGoogleAuth.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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

        public string GetInfo()
        {
            var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;
            var Email = HttpContext.User.Identity.Name;
            var gender = identity.Claims.Where(c => c.Type == ClaimTypes.Gender).Select(c => c.Value).SingleOrDefault();
            var age = identity.Claims.Where(c => c.Type == "age").Select(c => c.Value).SingleOrDefault();

            return "<p>Эл. адрес: " + Email + "</p><p>Пол: " + gender + "</p><p>Возраст: " + age + "</p>";


        }
    }
}