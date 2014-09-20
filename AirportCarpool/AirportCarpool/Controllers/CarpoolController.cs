using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AirportCarpool.Controllers {
    public class CarpoolController : Controller {
        //
        // GET: /Carpool/
        public ActionResult Index() {
            return View();
        }

        public ActionResult NewCarpool()
        {
            return View();
        }

        public ActionResult NewMovement() {
            ViewBag.LocationFrom = new SelectList((new string[] {"Home", "Schiphol", "Other address"}).ToList());
            ViewBag.LocationTo = ViewBag.LocationFrom;

            return View();
        }
        public ActionResult NewMovement2() {
            return View();
        }
    }
}