using Ballpark.Models;
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
        public ActionResult Index()
        {
            var model = new ProfileListItem[0];
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
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }
    }
}