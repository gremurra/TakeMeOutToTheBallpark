using Ballpark.Models;
using Ballpark.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ballpark.WebMVC.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        // GET: Profile
        public ActionResult Index()     //displays all the notes for the current user.
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new ProfileService(userID);
            var model = service.GetProfiles();

            return View(model);
        }

        // GET: Profile
        //Profile/Create
        public ActionResult Create()        //making a request to get the Create View
        {
            return View();
        }

        // POST: Profile
        //Profile/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProfileCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateProfileService();

            if (service.CreateProfile(model))
            {
                TempData["SaveResult"] = "Your profile was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Profile could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateProfileService();
            var model = svc.GetProfileByID(id);

            return View(model);
        }

        private ProfileService CreateProfileService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new ProfileService(userID);
            return service;
        }
    }
}