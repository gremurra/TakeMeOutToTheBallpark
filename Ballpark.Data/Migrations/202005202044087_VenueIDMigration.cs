namespace Ballpark.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VenueIDMigration : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Team", "Sport");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Team", "Sport", c => c.Int(nullable: false));
        }
    }
}
