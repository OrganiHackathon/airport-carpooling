namespace AirportCarpool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExtraFields : DbMigration
    {
        public override void Up()
        {
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
            DropTable("dbo.Users");
        }
    }
}
