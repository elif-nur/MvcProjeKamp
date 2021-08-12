namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class statuss : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Messages", "MessageStatus");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Messages", "MessageStatus", c => c.Boolean(nullable: false));
        }
    }
}
