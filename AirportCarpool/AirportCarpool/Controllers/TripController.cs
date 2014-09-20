using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AirportCarpool.Models;
using AirportCarpool.Services;

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
                        SearchFlights(newTrip);
                        return View("NewTrip02", newTrip);
                    }

                    // Invalid:
                    return View("NewTrip01", newTrip);
                case "NewTrip02":
                    if (newTrip.FlightNumber != "") {
                        return View("NewTrip03", newTrip);
                    }
                    SearchFlights(newTrip);
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

        private void SearchFlights(NewTrip newTrip) {
            var locationFrom = newTrip.LocationFrom;
            var locationTo = newTrip.LocationTo;
            FlightService flightService = new FlightService();
            List<Flight> flights = flightService.SearchFlights(newTrip.MovementDate);
            List<Flight> remove = new List<Flight>();
            foreach (var flight in flights) {
                if ((locationFrom == "Schiphol" && flight.ArrDep == "D") || (locationTo == "Schiphol" && flight.ArrDep == "A")) {
                    remove.Add(flight);
                } else {
                    TimeSpan flightTime;
                    TimeSpan minimum;
                    TimeSpan maximum;
                    if (flight.ArrDep == "A") {
                        flightTime = flight.Arrival.TimeOfDay;
                        minimum = newTrip.MovementTime.AddHours(-1).TimeOfDay;
                        maximum = newTrip.MovementTime.AddHours(1).TimeOfDay;
                    } else {
                        flightTime = flight.Departure.TimeOfDay;
                        minimum = newTrip.MovementTime.AddHours(1).TimeOfDay;
                        maximum = newTrip.MovementTime.AddHours(3).TimeOfDay;
                    }
                    if (flightTime < minimum || flightTime > maximum) {
                        remove.Add(flight);
                    }
                }
            }
            foreach (var flight in remove) {
                flights.Remove(flight);
            }
            ViewBag.ListFlights = flights;
        }

        private void SaveNewTrip(NewTrip newTrip) {

        }
    }
}