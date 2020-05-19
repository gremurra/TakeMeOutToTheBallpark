using Ballpark.Models.Event;
using Ballpark.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ballpark.WebMVC.Controllers
{
    [Authorize]
    public class EventController : Controller
    {
        // GET: Event
        public ActionResult Index()
        {
            var service = new EventService();
            var model = service.GetEvents();
            return View(model);
        }

        // GET: Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EventCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = new EventService();

            service.CreateEvent(model);

            return RedirectToAction("Index");
        }
    }
}