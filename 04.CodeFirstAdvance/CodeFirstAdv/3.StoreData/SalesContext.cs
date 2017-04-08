namespace _3.StoreData
{
    using Migrations;
    using StoreModels;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class SalesContext : DbContext
    {

        public SalesContext()
            : base("name=SalesContext")
        {
            //Database.SetInitializer(new InitializeAndSeed());
            //this.Database.Initialize(true);
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SalesContext, Configuration>());
        }
        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<Customer> Customers { get; set; }

        public virtual DbSet<StoreLocatoin> StoreLocations { get; set; }

        public virtual DbSet<Sale> Sales { get; set; }


    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}