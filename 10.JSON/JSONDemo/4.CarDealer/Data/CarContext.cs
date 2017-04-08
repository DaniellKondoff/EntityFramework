namespace CarDealer.Data
{
    using Models;
    using ModelsConfiguration;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class CarContext : DbContext
    {
        public CarContext()
            : base("name=CarContext")
        {
            //Database.SetInitializer(new DropCreateDatabaseAlways<CarContext>());
        }


        public virtual DbSet<Car> Cars { get; set; }

        public virtual DbSet<Part> Parts { get; set; }

        public virtual DbSet<Supplier> Suppliers { get; set; }

        public virtual DbSet<Customer> Customers { get; set; }

        public virtual DbSet<Sale> Sales { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CarConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }

     
}