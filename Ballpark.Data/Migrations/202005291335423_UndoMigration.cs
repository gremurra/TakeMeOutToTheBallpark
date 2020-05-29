namespace Ballpark.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UndoMigration : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Event", "HomeName");
            DropColumn("dbo.Event", "AwayName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Event", "AwayName", c => c.String());
            AddColumn("dbo.Event", "HomeName", c => c.String());
        }
    }
}
