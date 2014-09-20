namespace AirportCarpool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carpools",
                c => new
                    {
                        CarpoolId = c.Int(nullable: false, identity: true),
                        MaxSeats = c.Int(nullable: false),
                        MaxLuggage = c.Int(nullable: false),
                        MaxKm = c.Int(nullable: false),
                        Arrival = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CarpoolId);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        LocationId = c.Int(nullable: false, identity: true),
                        Street = c.String(),
                        StreetNr = c.String(),
                        PostalCode = c.String(),
                        City = c.String(),
                        Country = c.String(),
                        Geolocation = c.String(),
                    })
                .PrimaryKey(t => t.LocationId);
            
            CreateTable(
                "dbo.MovementDetails",
                c => new
                    {
                        MovementDetailId = c.Int(nullable: false, identity: true),
                        FlightId = c.Int(),
                        FlightNumber = c.String(),
                        Date = c.DateTime(),
                        Departure = c.DateTime(),
                        Arrival = c.DateTime(),
                        Movement_MovementId = c.Int(),
                    })
                .PrimaryKey(t => t.MovementDetailId)
                .ForeignKey("dbo.Movements", t => t.Movement_MovementId)
                .Index(t => t.Movement_MovementId);
            
            CreateTable(
                "dbo.Movements",
                c => new
                    {
                        MovementId = c.Int(nullable: false, identity: true),
                        Driver = c.Boolean(nullable: false),
                        Passenger = c.Boolean(nullable: false),
                        Seats = c.Int(nullable: false),
                        Luggage = c.Int(nullable: false),
                        MaxSeats = c.Int(nullable: false),
                        MaxLuggage = c.Int(nullable: false),
                        MaxKm = c.Int(nullable: false),
                        LocationFrom_LocationId = c.Int(),
                        LocationTo_LocationId = c.Int(),
                        User_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.MovementId)
                .ForeignKey("dbo.Locations", t => t.LocationFrom_LocationId)
                .ForeignKey("dbo.Locations", t => t.LocationTo_LocationId)
                .ForeignKey("dbo.Users", t => t.User_UserId)
                .Index(t => t.LocationFrom_LocationId)
                .Index(t => t.LocationTo_LocationId)
                .Index(t => t.User_UserId);
           
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Email = c.String(),
                        Name = c.String(),
                        SurName = c.String(),
                        GSM = c.String(),
                        Street = c.String(),
                        StreetNr = c.String(),
                        PostalCode = c.String(),
                        City = c.String(),
                        GeoLocation = c.String(),
                        Country = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
             
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movements", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.MovementDetails", "Movement_MovementId", "dbo.Movements");
            DropForeignKey("dbo.Movements", "LocationTo_LocationId", "dbo.Locations");
            DropForeignKey("dbo.Movements", "LocationFrom_LocationId", "dbo.Locations");
            DropIndex("dbo.Movements", new[] { "User_UserId" });
            DropIndex("dbo.Movements", new[] { "LocationTo_LocationId" });
            DropIndex("dbo.Movements", new[] { "LocationFrom_LocationId" });
            DropIndex("dbo.MovementDetails", new[] { "Movement_MovementId" });
            DropTable("dbo.Users");
            DropTable("dbo.Movements");
            DropTable("dbo.MovementDetails");
            DropTable("dbo.Locations");
            DropTable("dbo.Carpools");
        }
    }
}
