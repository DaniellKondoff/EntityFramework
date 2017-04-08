namespace BookShopSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRelatedBooks : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RelatedBooks",
                c => new
                    {
                        BookId = c.Int(nullable: false),
                        RelatedId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.BookId, t.RelatedId })
                .ForeignKey("dbo.Books", t => t.BookId)
                .ForeignKey("dbo.Books", t => t.RelatedId)
                .Index(t => t.BookId)
                .Index(t => t.RelatedId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RelatedBooks", "RelatedId", "dbo.Books");
            DropForeignKey("dbo.RelatedBooks", "BookId", "dbo.Books");
            DropIndex("dbo.RelatedBooks", new[] { "RelatedId" });
            DropIndex("dbo.RelatedBooks", new[] { "BookId" });
            DropTable("dbo.RelatedBooks");
        }
    }
}
