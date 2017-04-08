namespace Sales.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.StoreLocatoins", newName: "StoreLocations");
            AddColumn("dbo.Customers", "Name", c => c.String());
            AddColumn("dbo.Products", "Description", c => c.String());
            DropColumn("dbo.Customers", "FirstName");
            DropColumn("dbo.Customers", "LastName");
            DropColumn("dbo.Products", "Descirption");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Descirption", c => c.String());
            AddColumn("dbo.Customers", "LastName", c => c.String());
            AddColumn("dbo.Customers", "FirstName", c => c.String());
            DropColumn("dbo.Products", "Description");
            DropColumn("dbo.Customers", "Name");
            RenameTable(name: "dbo.StoreLocations", newName: "StoreLocatoins");
        }
    }
}
