﻿using Ballpark.Models.Venue;
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

        //Get: DETAILS
        public ActionResult Details (int id)
        {
            var svc = CreateVenueService();
            var model = svc.GetVenueByID(id);

            return View(model);
        }

        public ActionResult Edit (int id)
        {
            var service = CreateVenueService();
            var detail = service.GetVenueByID(id);
            var model =
                new VenueEdit
                {
                    VenueID = detail.VenueID,
                    VenueName = detail.VenueName,
                    Location = detail.Location,
                    YearOpened = detail.YearOpened,
                    Capacity = detail.Capacity,
                    IsActive = detail.IsActive
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, VenueEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.VenueID != id)
            {
                ModelState.AddModelError("", "ID Mismatch");
                return View(model);
            }

            var service = CreateVenueService();

            if (service.UpdateVenue(model))
            {
                TempData["SaveResult"] = "Your venue was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your venue could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateVenueService();
            var model = svc.GetVenueByID(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateVenueService();

            service.DeleteVenue(id);

            TempData["SaveResult"] = "Your venue was deleted.";

            return RedirectToAction("Index");
        }

        private static VenueService CreateVenueService()
        {
            return new VenueService();
        }
    }
}