﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationOWINClaimsIdentity.Models;

namespace WebApplicationOWINClaimsIdentity.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "admin")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            var id = User.Identity.GetUserId<int>();

            ViewBag.Message = string.Format("Your id is {0}", id);

            return View();
        }
    }
}