using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;

namespace RoleTest.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            return  View();
        }

        
       
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public async Task<ActionResult> MyRoles()
        {
            IList<String> roles = new List<string> { "Роль не определена" };
            ApplicationUserManager userManager = HttpContext.GetOwinContext().Get<ApplicationUserManager>();

            var user = await userManager.FindByIdAsync(User.Identity.Name);

            if (user != null)
                roles = await userManager.GetRolesAsync(user.Id);

            return View(roles);
        }


        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


    }
}