namespace CharitaPoll.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Polls", "UserId", "dbo.Users");
            DropIndex("dbo.Polls", new[] { "UserId" });
            CreateTable(
                "dbo.Surveys",
                c => new
                    {
                        SurveyId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CompanyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SurveyId)
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: true)
                .Index(t => t.CompanyId);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        CompanyId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Username = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.CompanyId);
            
            AddColumn("dbo.Polls", "SurveyId", c => c.Int(nullable: false));
            AlterColumn("dbo.Polls", "DateCreated", c => c.DateTime());
            CreateIndex("dbo.Polls", "SurveyId");
            AddForeignKey("dbo.Polls", "SurveyId", "dbo.Surveys", "SurveyId", cascadeDelete: true);
            DropColumn("dbo.Polls", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Polls", "UserId", c => c.Int());
            DropForeignKey("dbo.Polls", "SurveyId", "dbo.Surveys");
            DropForeignKey("dbo.Surveys", "CompanyId", "dbo.Companies");
            DropIndex("dbo.Surveys", new[] { "CompanyId" });
            DropIndex("dbo.Polls", new[] { "SurveyId" });
            AlterColumn("dbo.Polls", "DateCreated", c => c.DateTime(nullable: false));
            DropColumn("dbo.Polls", "SurveyId");
            DropTable("dbo.Companies");
            DropTable("dbo.Surveys");
            CreateIndex("dbo.Polls", "UserId");
            AddForeignKey("dbo.Polls", "UserId", "dbo.Users", "UserId");
        }
    }
}
