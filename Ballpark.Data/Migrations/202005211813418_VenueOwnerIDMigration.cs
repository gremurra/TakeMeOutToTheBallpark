namespace Ballpark.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VenueOwnerIDMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Venue", "OwnerID", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Venue", "OwnerID");
        }
    }
}
