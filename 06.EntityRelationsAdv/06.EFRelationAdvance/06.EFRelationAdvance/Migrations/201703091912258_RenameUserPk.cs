namespace EFRelationAdvance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameUserPk : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Chirps", "AuthorId", "dbo.People");
            DropIndex("dbo.Chirps", new[] { "AuthorId" });
            DropPrimaryKey("dbo.People");
            DropColumn("dbo.People", "Id");
            AddColumn("dbo.People", "Key", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Chirps", "Author_Key", c => c.Int());
            AddPrimaryKey("dbo.People", "Key");
            CreateIndex("dbo.Chirps", "Author_Key");
            AddForeignKey("dbo.Chirps", "Author_Key", "dbo.People", "Key");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Chirps", "Author_Key", "dbo.People");
            DropIndex("dbo.Chirps", new[] { "Author_Key" });
            DropPrimaryKey("dbo.People");
            DropColumn("dbo.Chirps", "Author_Key");
            DropColumn("dbo.People", "Key");
            AddColumn("dbo.People", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.People", "Id");
            CreateIndex("dbo.Chirps", "AuthorId");
            AddForeignKey("dbo.Chirps", "AuthorId", "dbo.People", "Id", cascadeDelete: true);
        }
    }
}
