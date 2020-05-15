namespace Ballpark.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProfileDateTimeMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Profile", "CreatedUtc", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Profile", "CreatedUtc");
        }
    }
}
