namespace CharitaPoll.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        AnswerId = c.Int(nullable: false, identity: true),
                        ChoosedAnswer = c.String(),
                        PollId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AnswerId)
                .ForeignKey("dbo.Polls", t => t.PollId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.PollId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Polls",
                c => new
                    {
                        PollId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        PriceRange = c.Int(nullable: false),
                        Definition = c.String(),
                        Option1 = c.String(),
                        Option2 = c.String(),
                        UserId = c.Int(),
                        CharityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PollId)
                .ForeignKey("dbo.Charities", t => t.CharityId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.CharityId);
            
            CreateTable(
                "dbo.Charities",
                c => new
                    {
                        CharityId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CharityId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Gender = c.String(),
                        DateOfBirth = c.DateTime(),
                        Country = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Polls", "UserId", "dbo.Users");
            DropForeignKey("dbo.Answers", "UserId", "dbo.Users");
            DropForeignKey("dbo.Polls", "CharityId", "dbo.Charities");
            DropForeignKey("dbo.Answers", "PollId", "dbo.Polls");
            DropIndex("dbo.Polls", new[] { "CharityId" });
            DropIndex("dbo.Polls", new[] { "UserId" });
            DropIndex("dbo.Answers", new[] { "UserId" });
            DropIndex("dbo.Answers", new[] { "PollId" });
            DropTable("dbo.Users");
            DropTable("dbo.Charities");
            DropTable("dbo.Polls");
            DropTable("dbo.Answers");
        }
    }
}
