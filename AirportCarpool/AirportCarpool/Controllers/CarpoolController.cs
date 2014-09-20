using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AirportCarpool.Models;

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
            NewMovementFillViewBag();
            return View(new NewMovement());
        }

        [HttpPost]
        public ActionResult NewMovement(NewMovement newMovement) {
            var locationFrom = newMovement.LocationFrom;
            var locationTo = newMovement.LocationTo;

            var valid = ModelState.IsValid;

            if (locationFrom == locationTo && locationFrom != "Other address" && locationTo != "Other address") {
                ModelState.AddModelError("LocationTo", string.Format("The location to ({0}) must be different from the location from ({1}).", locationTo, locationFrom));
                valid = false;
            }
            if (valid) {
                return View("");
            }
            
            // Invalid:
            NewMovementFillViewBag();
            return View(newMovement);
        }

        private void NewMovementFillViewBag() {
            ViewBag.LocationFrom = new SelectList((new string[] { "Home", "Schiphol", "Other address" }).ToList());
            ViewBag.LocationTo = ViewBag.LocationFrom;
        }

        public ActionResult NewMovementDetail(/*NewMovement newMovement,*/ int flightId)
        {
            return View("MovementDetail","");
         
        }
    }
}