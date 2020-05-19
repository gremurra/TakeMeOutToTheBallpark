namespace Ballpark.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewFirstMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Event", "VenueName", c => c.String(nullable: false));
            AddColumn("dbo.Event", "TeamName", c => c.String(nullable: false));
            DropColumn("dbo.Event", "VenueID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Event", "VenueID", c => c.Int(nullable: false));
            DropColumn("dbo.Event", "TeamName");
            DropColumn("dbo.Event", "VenueName");
        }
    }
}
