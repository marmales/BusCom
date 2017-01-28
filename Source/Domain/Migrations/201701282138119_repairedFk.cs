namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class repairedFk : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Messages", "AttachmentId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Messages", "AttachmentId", c => c.Int(nullable: false));
        }
    }
}
