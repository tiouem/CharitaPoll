namespace CharitaPoll.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Surveys", "CharityId", c => c.Int(nullable: false));
            CreateIndex("dbo.Surveys", "CharityId");
            AddForeignKey("dbo.Surveys", "CharityId", "dbo.Charities", "CharityId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Surveys", "CharityId", "dbo.Charities");
            DropIndex("dbo.Surveys", new[] { "CharityId" });
            DropColumn("dbo.Surveys", "CharityId");
        }
    }
}
