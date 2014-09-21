namespace AirportCarpool.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.Security;
    using AirportCarpool.Models;
    using WebMatrix.WebData;

    internal sealed class Configuration : DbMigrationsConfiguration<AirportCarpool.Models.AirportCarpoolDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(AirportCarpool.Models.AirportCarpoolDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //


            context.Carpools.AddOrUpdate(
                                              c => c.CarpoolId,
                                              new Carpool { MaxLuggage = 4, MaxSeats = 4, MaxKm = 15, Arrival = DateTime.Now.AddHours(1), Status = CarpoolStatus.New },
                                              new Carpool { MaxLuggage = 2, MaxSeats = 1, MaxKm = 25, Arrival = DateTime.Now.AddHours(1), Status = CarpoolStatus.New },
                                              new Carpool { MaxLuggage = 1, MaxSeats = 1, MaxKm = 15, Arrival = DateTime.Now.AddHours(1), Status = CarpoolStatus.New },
                                              new Carpool { MaxLuggage = 6, MaxSeats = 4, MaxKm = 15, Arrival = DateTime.Now.AddHours(2), Status = CarpoolStatus.New },
                                              new Carpool { MaxLuggage = 4, MaxSeats = 0, MaxKm = 15, Arrival = DateTime.Now.AddHours(2), Status = CarpoolStatus.New },
                                              new Carpool { MaxLuggage = 4, MaxSeats = 1, MaxKm = 15, Arrival = DateTime.Now.AddHours(2), Status = CarpoolStatus.New },
                                              new Carpool { MaxLuggage = 2, MaxSeats = 4, MaxKm = 35, Arrival = DateTime.Now.AddHours(2), Status = CarpoolStatus.Full },
                                              new Carpool { MaxLuggage = 1, MaxSeats = 4, MaxKm = 15, Arrival = DateTime.Now.AddHours(2), Status = CarpoolStatus.New },
                                              new Carpool { MaxLuggage = 4, MaxSeats = 4, MaxKm = 15, Arrival = DateTime.Now.AddHours(3), Status = CarpoolStatus.New },
                                              new Carpool { MaxLuggage = 3, MaxSeats = 4, MaxKm = 20, Arrival = DateTime.Now.AddHours(3), Status = CarpoolStatus.New },
                                              new Carpool { MaxLuggage = 3, MaxSeats = 4, MaxKm = 15, Arrival = DateTime.Now.AddHours(3), Status = CarpoolStatus.Full },
                                              new Carpool { MaxLuggage = 2, MaxSeats = 4, MaxKm = 15, Arrival = DateTime.Now.AddHours(4), Status = CarpoolStatus.New },
                                              new Carpool { MaxLuggage = 2, MaxSeats = 4, MaxKm = 15, Arrival = DateTime.Now.AddHours(4), Status = CarpoolStatus.New },
                                              new Carpool { MaxLuggage = 2, MaxSeats = 0, MaxKm = 10, Arrival = DateTime.Now.AddHours(5), Status = CarpoolStatus.New },
                                              new Carpool { MaxLuggage = 1, MaxSeats = 4, MaxKm = 15, Arrival = DateTime.Now.AddHours(5), Status = CarpoolStatus.Full },
                                              new Carpool { MaxLuggage = 0, MaxSeats = 3, MaxKm = 5, Arrival = DateTime.Now.AddHours(-1), Status = CarpoolStatus.New },
                                              new Carpool { MaxLuggage = 0, MaxSeats = 4, MaxKm = 15, Arrival = DateTime.Now.AddHours(-1), Status = CarpoolStatus.New },
                                              new Carpool { MaxLuggage = 0, MaxSeats = 3, MaxKm = 15, Arrival = DateTime.Now.AddHours(-1), Status = CarpoolStatus.Full },
                                              new Carpool { MaxLuggage = 1, MaxSeats = 4, MaxKm = 25, Arrival = DateTime.Now.AddHours(-1), Status = CarpoolStatus.New },
                                              new Carpool { MaxLuggage = 2, MaxSeats = 4, MaxKm = 15, Arrival = DateTime.Now.AddHours(-1), Status = CarpoolStatus.New },
                                              new Carpool { MaxLuggage = 3, MaxSeats = 2, MaxKm = 15, Arrival = DateTime.Now.AddHours(-1), Status = CarpoolStatus.New },
                                              new Carpool { MaxLuggage = 10, MaxSeats = 4, MaxKm = 15, Arrival = DateTime.Now.AddHours(-2), Status = CarpoolStatus.New },
                                              new Carpool { MaxLuggage = 2, MaxSeats = 4, MaxKm = 15, Arrival = DateTime.Now.AddHours(4), Status = CarpoolStatus.New },
                                              new Carpool { MaxLuggage = 2, MaxSeats = 1, MaxKm = 5, Arrival = DateTime.Now.AddHours(3), Status = CarpoolStatus.New },
                                              new Carpool { MaxLuggage = 2, MaxSeats = 4, MaxKm = 2, Arrival = DateTime.Now.AddHours(2), Status = CarpoolStatus.Full },
                                              new Carpool { MaxLuggage = 1, MaxSeats = 4, MaxKm = 15, Arrival = DateTime.Now.AddHours(-4), Status = CarpoolStatus.New },
                                              new Carpool { MaxLuggage = 0, MaxSeats = 4, MaxKm = 15, Arrival = DateTime.Now.AddHours(-1), Status = CarpoolStatus.Full }
    
                                            );
        }

        
    }
}
