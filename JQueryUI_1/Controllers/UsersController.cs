using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using JQueryUI_1.Models;

namespace JQueryUI_1.Controllers
{
    public class UsersController : Controller
    {
        public ApplicationDbContext db = ApplicationDbContext.Create();

        public ActionResult getUser(string id)
        {
            ApplicationUser user = db.Users.FirstOrDefault(u => u.Id == id);

            return Json(user, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult getPassword(string id)
        {
            ApplicationUser user = db.Users.FirstOrDefault(u => u.Id == id);

            return Json(user.PasswordHash, JsonRequestBehavior.AllowGet);
        }



        // GET: Users
        public ActionResult getUsers()
        {
            List<ApplicationUser> users = db.Users.Select(u=>u).ToList();

            return Json(users, JsonRequestBehavior.AllowGet);
        }
    }
}