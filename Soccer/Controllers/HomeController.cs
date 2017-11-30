using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Soccer.Models;

namespace Soccer.Controllers
{
    public class HomeController : Controller
    {
        SoccerContext db = new SoccerContext();

        public ActionResult Index()
        {
            var players = db.Players.Include(p => p.Team);
            return View(players.ToList());
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

        public ActionResult TeamDetails(int? id)
        {
            if(id == null)
            {
                return HttpNotFound();
            }

            Team team = db.Teams.Include(t => t.Players).FirstOrDefault(t => t.Id == id);

            if(team == null)
            {
                return HttpNotFound();
            }

            return View(team);

        }

        [HttpGet]
        public ActionResult Create()
        {
            SelectList teams = new SelectList(db.Teams, "id", "Name");
            ViewBag.Teams = teams;
            return View();

        }
        [HttpPost]
        public ActionResult Create(Player player)
        {
            db.Players.Add(player);
            db.SaveChanges();

            return RedirectToAction("index");
        }
    }
}