namespace BookShopSystem.Client
{
    using Migrations;
    using ModelConfiguration;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class BookShopContext : DbContext
    {

        public BookShopContext()
            : base("name=BookShopContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BookShopContext, Configuration>());
        }

        public virtual DbSet<Book> Books { get; set; }

        public virtual DbSet<Author> Authors { get; set; }

        public virtual DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new BookConfiguration());
            base.OnModelCreating(modelBuilder);
        }

    }


}