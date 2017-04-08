namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedStudioRevenue : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Studios", "Revenue", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Studios", "Revenue");
        }
    }
}
