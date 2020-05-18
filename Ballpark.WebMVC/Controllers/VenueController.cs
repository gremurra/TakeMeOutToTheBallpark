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
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = new VenueService();

            service.CreateVenue(model);

            return RedirectToAction("Index");
        }
    }
}