namespace Ballpark.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FourDataTableMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Event",
                c => new
                    {
                        EventID = c.Int(nullable: false, identity: true),
                        ProfileID = c.Int(nullable: false),
                        DateOfGame = c.DateTimeOffset(nullable: false, precision: 7),
                        VenueID = c.Int(nullable: false),
                        TeamID = c.Int(nullable: false),
                        AwayTeam = c.String(nullable: false),
                        Result = c.String(nullable: false),
                        Comments = c.String(),
                    })
                .PrimaryKey(t => t.EventID)
                .ForeignKey("dbo.Profile", t => t.ProfileID, cascadeDelete: true)
                .ForeignKey("dbo.Team", t => t.TeamID, cascadeDelete: true)
                .Index(t => t.ProfileID)
                .Index(t => t.TeamID);
            
            CreateTable(
                "dbo.Profile",
                c => new
                    {
                        ProfileID = c.Int(nullable: false, identity: true),
                        OwnerID = c.Guid(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        FavTeam = c.String(),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.ProfileID);
            
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
            
            CreateTable(
                "dbo.Venue",
                c => new
                    {
                        VenueID = c.Int(nullable: false, identity: true),
                        VenueName = c.String(nullable: false),
                        Location = c.String(nullable: false),
                        YearOpened = c.Int(nullable: false),
                        Capacity = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.VenueID);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Event", "TeamID", "dbo.Team");
            DropForeignKey("dbo.Team", "VenueID", "dbo.Venue");
            DropForeignKey("dbo.Event", "ProfileID", "dbo.Profile");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Team", new[] { "VenueID" });
            DropIndex("dbo.Event", new[] { "TeamID" });
            DropIndex("dbo.Event", new[] { "ProfileID" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Venue");
            DropTable("dbo.Team");
            DropTable("dbo.Profile");
            DropTable("dbo.Event");
        }
    }
}
