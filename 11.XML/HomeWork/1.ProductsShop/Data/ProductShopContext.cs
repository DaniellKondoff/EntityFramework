namespace ProductsShop.Data
{
    using ModelConfiguration;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ProductShopContext : DbContext
    {

        public ProductShopContext()
            : base("name=ProductShopContext")
        {
            //Database.SetInitializer(new DropCreateDatabaseAlways<ProductShopContext>());
        }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new ProductConfiguration());
            base.OnModelCreating(modelBuilder);
        }

    }

}