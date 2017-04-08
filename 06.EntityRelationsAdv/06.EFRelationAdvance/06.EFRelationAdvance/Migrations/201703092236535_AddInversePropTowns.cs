namespace EFRelationAdvance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddInversePropTowns : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.People1",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        PlaceOfBirthId = c.Int(),
                        CurrentResidenseId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Towns", t => t.CurrentResidenseId)
                .ForeignKey("dbo.Towns", t => t.PlaceOfBirthId)
                .Index(t => t.PlaceOfBirthId)
                .Index(t => t.CurrentResidenseId);
            
            CreateTable(
                "dbo.Towns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.People1", "PlaceOfBirthId", "dbo.Towns");
            DropForeignKey("dbo.People1", "CurrentResidenseId", "dbo.Towns");
            DropIndex("dbo.People1", new[] { "CurrentResidenseId" });
            DropIndex("dbo.People1", new[] { "PlaceOfBirthId" });
            DropTable("dbo.Towns");
            DropTable("dbo.People1");
        }
    }
}
