namespace _3.StoreData.Migrations
{
    using StoreModels;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using _3.StoreData;



    internal sealed class Configuration : DbMigrationsConfiguration<SalesContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            this.AutomaticMigrationDataLossAllowed = true;

        }

        protected override void Seed(SalesContext context)
        {
            context.Products.AddOrUpdate(new Product() { Name = "Car", Descirption = "Vechile" });
            context.Customers.AddOrUpdate(new Customer() { FirstName = "Teo", LastName = "Todor" });       
        }
    }
}
