namespace Sales
{
    using Migrations;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class SaleContext : DbContext
    {

        public SaleContext()
            : base("name=SaleContext")
        {
            //Database.SetInitializer(new CreateDatabaseIfNotExists<SaleContext>());
            //this.Database.Initialize(true);
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SaleContext, Configuration>());
        }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<Customer> Customers { get; set; }

        public virtual DbSet<StoreLocation> StoreLocations { get; set; }

        public virtual DbSet<Sale> Sales { get; set; }
    }

}