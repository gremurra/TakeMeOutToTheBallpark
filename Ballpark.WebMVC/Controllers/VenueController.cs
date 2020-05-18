using Ballpark.Models.Venue;
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
            var model = new VenueListItem[0];
            return View(model);
        }
    }
}