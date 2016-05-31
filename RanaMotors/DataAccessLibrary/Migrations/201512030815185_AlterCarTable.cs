namespace DataAccessLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterCarTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cars", "OdoMeterReading", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cars", "OdoMeterReading");
        }
    }
}
