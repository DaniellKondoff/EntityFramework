namespace AdvanceQuerying.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAddressToClient : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clients", "Adrress", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Clients", "Adrress");
        }
    }
}
