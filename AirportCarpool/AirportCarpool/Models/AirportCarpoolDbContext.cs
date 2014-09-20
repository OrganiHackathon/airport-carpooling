using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AirportCarpool.Models {
    public class AirportCarpoolDbContext : DbContext {
        
        public DbSet<User> Users { get; set; }
        public DbSet<Movement> Movements { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<MovementDetail> MovementDetails { get; set; }
        public DbSet<Carpool> Carpools { get; set; }

        public System.Data.Entity.DbSet<AirportCarpool.Models.Flight> Flights { get; set; }
    }
}