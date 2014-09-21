using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AirportCarpool.Models;
using AirportCarpool.Services;
using WebMatrix.WebData;

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

        private Movement SaveNewTrip(NewTrip newTrip) {
            var movement = new Movement();
            var db = new AirportCarpoolDbContext();
            db.Entry(movement).State = EntityState.Added;

            var user = GetUserByUserName(db, WebSecurity.CurrentUserName);
            db.Entry(user).State = EntityState.Unchanged;

            movement.User = user;
            Location locationFrom = null;
            if (newTrip.LocationFrom == "Home" && user.Location != null) {
                locationFrom = Location.GetCopy(user.Location);
            } else if (newTrip.LocationFrom == "Schiphol") {
                locationFrom = Location.GetNewSchipholLocation();
            }
            if (locationFrom != null) {
                db.Entry(locationFrom).State = EntityState.Added;
                //db.SaveChanges();
            }
            movement.LocationFrom = locationFrom;

            Location locationTo = null;
            if (newTrip.LocationTo == "Home" && user.Location != null) {
                locationTo = Location.GetCopy(user.Location);
            } else if (newTrip.LocationTo == "Schiphol") {
                locationTo = Location.GetNewSchipholLocation();
            }
            if (locationTo != null) {
                db.Entry(locationTo).State = EntityState.Added;
                //db.SaveChanges();
            }
            movement.LocationTo = locationTo;

            movement.Driver = newTrip.Driver;
            movement.Passenger = newTrip.Passenger;
            movement.Seats = newTrip.Seats;
            movement.Luggage = newTrip.Luggage;
            if (newTrip.Driver) {
                movement.MaxSeats = newTrip.MaxSeats;
                movement.MaxLuggage = newTrip.MaxLuggage;
                movement.MaxKm = newTrip.MaxKm;
            }
            movement.MovementDateTime = newTrip.MovementDate.Add(newTrip.MovementTime.TimeOfDay);
            movement.MovementDateType = newTrip.MovementDateType;

            //if (newTrip.FlightNumber != "") {
            //    Flight flight = new Flight {
            //        FlightNumber = newTrip.FlightNumber,
            //        ArrDep = newTrip.ArrDep,
            //        Arrival = newTrip.Arrival,
            //        Departure = newTrip.Departure,
            //        Date = newTrip.MovementDate
            //    };
            //    flight.Movement = movement;
            //    //movement.MovementDetails = new List<MovementDetail>();
            //    //movement.MovementDetails.Add(flight);
            //    db.Entry(flight).State = EntityState.Added;
            //}
            
            db.SaveChanges();

            return movement;
        }

        private User GetUserByUserName(AirportCarpoolDbContext db, string userName) {
            return (from u in db.Users
                    where u.UserName == userName
                    select u).SingleOrDefault<User>();
        }
    }
}