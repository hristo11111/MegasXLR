namespace CrowdSourcedNews.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false),
                        Nickname = c.String(nullable: false),
                        AuthCode = c.String(nullable: false),
                        SessionKey = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateTable(
                "dbo.NewsArticles",
                c => new
                    {
                        NewsArticleID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Content = c.String(nullable: false),
                        AuthorID = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Rating = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.NewsArticleID)
                .ForeignKey("dbo.Users", t => t.AuthorID, cascadeDelete: true)
                .Index(t => t.AuthorID);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AuthorID = c.Int(nullable: false),
                        Content = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                        IsNested = c.Boolean(nullable: false),
                        Comment_ID = c.Int(),
                        NewsArticle_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.AuthorID, cascadeDelete: true)
                .ForeignKey("dbo.Comments", t => t.Comment_ID)
                .ForeignKey("dbo.NewsArticles", t => t.NewsArticle_ID)
                .Index(t => t.AuthorID)
                .Index(t => t.Comment_ID)
                .Index(t => t.NewsArticle_ID);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Comments", new[] { "NewsArticle_ID" });
            DropIndex("dbo.Comments", new[] { "Comment_ID" });
            DropIndex("dbo.Comments", new[] { "AuthorID" });
            DropIndex("dbo.NewsArticles", new[] { "AuthorID" });
            DropForeignKey("dbo.Comments", "NewsArticle_ID", "dbo.NewsArticles");
            DropForeignKey("dbo.Comments", "Comment_ID", "dbo.Comments");
            DropForeignKey("dbo.Comments", "AuthorID", "dbo.Users");
            DropForeignKey("dbo.NewsArticles", "AuthorID", "dbo.Users");
            DropTable("dbo.Comments");
            DropTable("dbo.NewsArticles");
            DropTable("dbo.Users");
        }
    }
}
