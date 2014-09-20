using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AirportCarpool.Models;

namespace AirportCarpool.Controllers {
    public class TripController : Controller {

        public ActionResult NewTrip() {
            return View("NewTrip01", new NewTrip());
        }

        [HttpPost]
        public ActionResult NewTrip(NewTrip newTrip) {
            var view = HttpContext.Request["View"];
            switch (view) {
                case "NewTrip01":
                    var locationFrom = newTrip.LocationFrom;
                    var locationTo = newTrip.LocationTo;

                    var valid = ModelState.IsValid;

                    if (locationFrom == locationTo) {
                        ModelState.AddModelError("LocationTo", string.Format("The location to ({0}) must be different from the location from ({1}).", locationTo, locationFrom));
                        valid = false;
                    }
                    if (valid) {
                        // TODO: 02 of 03?
                        return View("NewTrip03", newTrip);
                    }

                    // Invalid:
                    return View("NewTrip01", newTrip);
                case "NewTrip02":
                    if (ModelState.IsValid) {
                        return View("NewTrip03", newTrip);
                    }
                    return View("NewTrip02", newTrip);
                case "NewTrip03":
                    valid = ModelState.IsValid;
                    if (!newTrip.Driver && !newTrip.Passenger) {
                        ModelState.AddModelError("Passenger", "Please choose at least one of these options.");
                        valid = false;
                    }
                    if (valid) {
                        if (newTrip.Driver) {
                            return View("NewTrip04", newTrip);
                        } else {
                            SaveNewTrip(newTrip);
                        }
                    }
                    return View("NewTrip03", newTrip);
                case "NewTrip04":
                    if (ModelState.IsValid) {
                        SaveNewTrip(newTrip);
                        return RedirectToAction("Index", "Home");
                    }
                    return View("NewTrip04", newTrip);

            }
            // Unknown:
            return View(view, newTrip);
        }

        private void SaveNewTrip(NewTrip newTrip) {

        }
    }
}