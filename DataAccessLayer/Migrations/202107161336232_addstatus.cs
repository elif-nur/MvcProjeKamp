namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addstatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "MessageStatus1", c => c.Boolean(nullable: false));
            
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Messages", "MessageStatus", c => c.String());
            DropColumn("dbo.Messages", "MessageStatus1");
        }
    }
}
