namespace CharitaPoll.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Polls", "UserId", "dbo.Users");
            DropIndex("dbo.Polls", new[] { "UserId" });
            AlterColumn("dbo.Polls", "UserId", c => c.Int());
            CreateIndex("dbo.Polls", "UserId");
            AddForeignKey("dbo.Polls", "UserId", "dbo.Users", "UserId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Polls", "UserId", "dbo.Users");
            DropIndex("dbo.Polls", new[] { "UserId" });
            AlterColumn("dbo.Polls", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Polls", "UserId");
            AddForeignKey("dbo.Polls", "UserId", "dbo.Users", "UserId", cascadeDelete: true);
        }
    }
}
