using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AirportCarpool.Models;
using AirportCarpool.Services;

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
            return View(new NewTrip());
        }

        [HttpPost]
        public ActionResult NewMovement(NewTrip newMovement) {
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

        
        public ActionResult FindCarpoolsByDate(int movementId)
        {
            CarpoolService carpoolService = new CarpoolService();
            List<Carpool> carpools;

            
            // voor test

            carpools = carpoolService.FindCarpoolsByDateTime(newMovement.MovementDateTime);
            ViewData["newMovement"] = newMovement;
            return View("CarpoolList", carpools);         
        }

        public ActionResult Details(int id)
        {
            CarpoolService carpoolService = new CarpoolService();
            Carpool carpool = carpoolService.FindCarpoolById(id);
            return View(carpool);
        }

        public ActionResult AddMovementToCarpool(Carpool selectedCarpool, Movement newMovement)
        {
            CarpoolService carpoolService = new CarpoolService();
            Carpool newCarpool = carpoolService.AddMovementToCarpool(selectedCarpool, newMovement);
            return View(newCarpool);
        }
    }
}