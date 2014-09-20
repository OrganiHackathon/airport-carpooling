﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AirportCarpool.Models;
using AirportCarpool.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AirportCarpool.Testing
{
     [TestClass]
    public class TestClass
    {

        FlightService flightService;
        CarpoolService carpoolservice;
        
    
         [TestMethod]
        public void TestFlightServiceByDate()
        {
            DateTime departure;
            List<Flight> flights;

            departure = DateTime.Now;

            flightService = new FlightService();

            flights = flightService.SearchFlights(departure);

            foreach (Flight flight in flights)
            {
                Console.WriteLine(flight.FlightNumber + ";" + flight.Arrival + ";" +  flight.Departure);
            }
        }
            [TestMethod]
         public void TestGetCarpoolsByDate()
         {
             DateTime arrival;
             List<Carpool> carpools;

             arrival = DateTime.Now;

             carpoolservice = new CarpoolService();

             carpools = carpoolservice.FindCarpoolsByDateTime(arrival);

             foreach (Carpool carpool in carpools)
             {
                 Console.WriteLine(carpool.CarpoolId + ";" + carpool.Status + ";" + carpool.MaxSeats);
             }
         }

         //[TestMethod]
         //public void TestFlightServiceByFlightNumber()
         //{
         //    DateTime departure;
         //    Flight flight;

         //    departure = DateTime.Now;

         //    flightService = new FlightService();

         //    flight = flightService.SearchFlightByFlightNumber("OR544","A");

            
         //    Console.WriteLine(flight.FlightNumber + ";" + flight.Arrival + ";" + flight.Departure);
             
         //}
   }
}