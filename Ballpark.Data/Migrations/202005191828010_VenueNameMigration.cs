namespace Ballpark.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VenueNameMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Team", "VenueName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Team", "VenueName");
        }
    }
}
