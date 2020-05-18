using Ballpark.Models.Venue;
using Ballpark.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ballpark.WebMVC.Controllers
{
    [Authorize]
    public class VenueController : Controller
    {
        // GET: Venue
        public ActionResult Index()
        {
            var service = new VenueService();
            var model = service.GetVenues();
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
        public ActionResult Create(VenueCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateVenueService();

            if (service.CreateVenue(model))
            {
                TempData["SaveResult"] = "Your venue was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Venue could not be created.");

            return View(model);
        }

        public ActionResult Details (int id)
        {
            var svc = CreateVenueService();
            var model = svc.GetVenueByID(id);

            return View(model);
        }

        private static VenueService CreateVenueService()
        {
            return new VenueService();
        }
    }
}