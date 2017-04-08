namespace BusTicketSystem.Data
{
    using BusTicketsystem.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class BusContext : DbContext
    {

        public BusContext()
            : base("name=BusContext")
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<BusContext>());
        }

        public virtual DbSet<BankAccount> BankAccounts { get; set; }
        public virtual DbSet<BusCompany> BusCompanies { get; set; }
        public virtual DbSet<BusStation> BusStations { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<Town> Towns { get; set; }
        public virtual DbSet<Trip> Trips { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BankAccount>().HasRequired(b => b.Customer).WithRequiredDependent(c => c.BankAccount);
            //modelBuilder.Entity<Customer>().HasMany(c => c.Reviews).WithRequired(r => r.Customer);
            base.OnModelCreating(modelBuilder);
        }
    } 
}