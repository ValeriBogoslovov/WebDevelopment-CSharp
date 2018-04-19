namespace PizzaForum.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Topics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        AuthorId = c.Int(nullable: false),
                        Content = c.String(),
                        PublishDate = c.DateTime(nullable: false),
                        Category_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.AuthorId, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .Index(t => t.AuthorId)
                .Index(t => t.Category_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        IsAdmin = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Replies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        AuthorId = c.Int(nullable: false),
                        PublishDate = c.DateTime(nullable: false),
                        ImageUrl = c.String(),
                        Topic_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.AuthorId, cascadeDelete: true)
                .ForeignKey("dbo.Topics", t => t.Topic_Id)
                .Index(t => t.AuthorId)
                .Index(t => t.Topic_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Topics", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.Replies", "Topic_Id", "dbo.Topics");
            DropForeignKey("dbo.Replies", "AuthorId", "dbo.Users");
            DropForeignKey("dbo.Topics", "AuthorId", "dbo.Users");
            DropIndex("dbo.Replies", new[] { "Topic_Id" });
            DropIndex("dbo.Replies", new[] { "AuthorId" });
            DropIndex("dbo.Topics", new[] { "Category_Id" });
            DropIndex("dbo.Topics", new[] { "AuthorId" });
            DropTable("dbo.Replies");
            DropTable("dbo.Users");
            DropTable("dbo.Topics");
            DropTable("dbo.Categories");
        }
    }
}
