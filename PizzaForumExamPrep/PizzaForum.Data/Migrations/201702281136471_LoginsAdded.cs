namespace PizzaForum.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LoginsAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Logins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SessionId = c.String(),
                        UserId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Logins", "UserId", "dbo.Users");
            DropIndex("dbo.Logins", new[] { "UserId" });
            DropTable("dbo.Logins");
        }
    }
}
