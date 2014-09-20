using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AirportCarpool.Models;
using AirportCarpool.Services;

namespace AirportCarpool.Controllers
{
    public class FlightController : Controller
    {
        //
        // GET: /Flight/
        public ActionResult Index()
        {
            /* test*/
            return View();
        }


        public ActionResult SearchFlightByDate(/*DateTime date*/)
        {
            FlightService flightService = new FlightService();
            List<Flight> flights = flightService.SearchFlights(/*date*/ DateTime.Now);

            return View("FlightList",flights);   
        }
          
      
    }
}
