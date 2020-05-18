namespace Ballpark.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TeamMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Team",
                c => new
                    {
                        TeamID = c.Int(nullable: false, identity: true),
                        TeamName = c.String(nullable: false),
                        Sport = c.Int(nullable: false),
                        Location = c.String(nullable: false),
                        VenueID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TeamID)
                .ForeignKey("dbo.Venue", t => t.VenueID, cascadeDelete: true)
                .Index(t => t.VenueID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Team", "VenueID", "dbo.Venue");
            DropIndex("dbo.Team", new[] { "VenueID" });
            DropTable("dbo.Team");
        }
    }
}
