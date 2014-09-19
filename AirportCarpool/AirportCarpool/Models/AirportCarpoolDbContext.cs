using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AirportCarpool.Models
{
    public class AirportCarpoolDbContext: DbContext
    {
        //public AirportCarpoolDbContext() : base("name=DefaultConnection") { }

        public DbSet<User> Users { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<UserFlight> UserFlights { get; set; }
        public DbSet<Trip> Trips { get; set; }
    }
}