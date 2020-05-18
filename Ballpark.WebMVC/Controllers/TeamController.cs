using Ballpark.Models.Team;
using Ballpark.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ballpark.WebMVC.Controllers
{
    [Authorize]
    public class TeamController : Controller
    {
        // GET: Team
        public ActionResult Index()
        {
            var service = new TeamService();
            var model = service.GetTeams();
            return View(model);
        }

        //GET: Create
        public ActionResult Create()
        {
            return View();
        }

        //POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TeamCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateTeamService();

            if (service.CreateTeam(model))
            {
                TempData["SaveResult"] = "Your team was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Team could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateTeamService();
            var model = svc.GetTeamByID(id);

            return View(model);
        }

        private static TeamService CreateTeamService()
        {
            return new TeamService();
        }
    }
}