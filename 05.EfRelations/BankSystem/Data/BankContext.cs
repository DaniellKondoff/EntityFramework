namespace Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Models;
    using Migrations;
    using Configurations;

    public class BankContext : DbContext
    {

        public BankContext()
            : base("name=BankContext.cs")
        {
            this.Configuration.LazyLoadingEnabled = true;
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BankContext, Configuration>());
        }

        public virtual DbSet<ChekingAccount> CheckingAccounts { get; set; }
        public virtual DbSet<SavingAccount> SavingAccounts { get; set; }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new SavinConfiguration());
            modelBuilder.Configurations.Add(new CheckingConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }


}