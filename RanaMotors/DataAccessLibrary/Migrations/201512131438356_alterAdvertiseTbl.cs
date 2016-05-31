namespace DataAccessLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alterAdvertiseTbl : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdvertiseCars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CarId = c.Int(nullable: false),
                        CompanyName = c.String(),
                        Model = c.String(),
                        Varient = c.String(),
                        OdoMeterReading = c.Int(nullable: false),
                        ManufacturedYear = c.Int(nullable: false),
                        SellingPrice = c.Int(nullable: false),
                        Contact = c.Int(nullable: false),
                        picture = c.Binary(),
                        FuelType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AdvertiseCars");
        }
    }
}
