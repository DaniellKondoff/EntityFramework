namespace EFRelationAdvance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetAliesChange : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.People", "Alias", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AlterColumn("dbo.Chirps", "content", c => c.String(nullable: false, maxLength: 130));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Chirps", "content", c => c.String(maxLength: 130));
            AlterColumn("dbo.People", "Alias", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
