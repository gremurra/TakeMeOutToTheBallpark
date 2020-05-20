namespace Ballpark.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMigration : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Team", "Location");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Team", "Location", c => c.String(nullable: false));
        }
    }
}
