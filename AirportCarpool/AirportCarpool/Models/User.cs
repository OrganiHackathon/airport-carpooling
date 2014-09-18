using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AirportCarpool.Models
{
    public class User
    {
        // Test gvh
        // test pds
        // Test Tce
        public int UserId {get;set;}
        public string UserName {get; set;}
        public string Email {get;set;}
        public string Name {get;set;}
        public string SurName {get;set;}
        public string GSM {get;set;}
        public string Street {get;set;}
        public string StreetNr {get;set;}
        public string PostalCode {get;set;}
        public string City {get;set;}
        public string GeoLocation {get;set;}
        public string Country {get;set;}        
    }

    public class UserDBContext : DbContext
    {
        public DbSet<User> Users{get;set;}
        public DbSet<Flight> Flights { get; set; }
        public DbSet<UserFlight> UserFlights { get; set; }
    }

    public class Flight
    {
        public int FlightId { get; set; }
        public string FlightNumber { get; set; }
        public DateTime Date { get; set; }
        public DateTime Departure { get; set; }
        public DateTime Arrival { get; set; }

    }

     public class UserFlight
    {
        public int UserFlightid { get; set; }
        public Flight flight { get; set; }
        public User user { get; set; }
    }
}