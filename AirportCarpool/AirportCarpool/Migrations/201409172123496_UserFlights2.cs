namespace AirportCarpool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserFlights2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Flights",
                c => new
                    {
                        FlightId = c.Int(nullable: false, identity: true),
                        FlightNumber = c.String(),
                        Date = c.DateTime(nullable: false),
                        Departure = c.DateTime(nullable: false),
                        Arrival = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.FlightId);
            
            CreateTable(
                "dbo.UserFlights",
                c => new
                    {
                        UserFlightid = c.Int(nullable: false, identity: true),
                        flight_FlightId = c.Int(),
                        user_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.UserFlightid)
                .ForeignKey("dbo.Flights", t => t.flight_FlightId)
                .ForeignKey("dbo.Users", t => t.user_UserId)
                .Index(t => t.flight_FlightId)
                .Index(t => t.user_UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserFlights", "user_UserId", "dbo.Users");
            DropForeignKey("dbo.UserFlights", "flight_FlightId", "dbo.Flights");
            DropIndex("dbo.UserFlights", new[] { "user_UserId" });
            DropIndex("dbo.UserFlights", new[] { "flight_FlightId" });
            DropTable("dbo.UserFlights");
            DropTable("dbo.Flights");
        }
    }
}
