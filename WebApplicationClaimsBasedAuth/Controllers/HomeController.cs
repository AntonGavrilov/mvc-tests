using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationClaimsBasedAuth.Util;
using WebApplicationClaimsBasedAuth.Models;

namespace WebApplicationClaimsBasedAuth.Controllers
{
    public class HomeController : Controller
    {
        //[ClaimsAuthorizeAttribure(Age = 18)]
        
        public ActionResult Index()
        {
            return View();
        }

        [ClaimsAuthorizeAttribure(Age = 18)]
        
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult MyArtists()
        {
            return View("Artists");

        }

        public ActionResult MyTracks()
        {
            List<Track> trackList = new List<Track>();

            for (int i = 0; i < 100; i++)
            {
                trackList.Add(new Track { Name = "Track name", Artist = new Artist { Name = String.Format("Name {0}",i), MusicStyle = "Punk"}, Duration = new TimeSpan(0, 4, 5) });
            }

            return View("Tracks", trackList);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}