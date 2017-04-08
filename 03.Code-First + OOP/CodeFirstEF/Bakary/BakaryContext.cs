namespace Bakary
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BakaryContext : DbContext
    {
        public BakaryContext()
            : base("name=BakaryContext")
        {
        }

        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Distributor> Distributors { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<Ingredient> Ingredients { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Country>()
                .HasMany(e => e.Ingredients)
                .WithOptional(e => e.Country)
                .HasForeignKey(e => e.OriginCountryId);

            modelBuilder.Entity<Customer>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Gender)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.PhoneNumber)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Distributor>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Distributor>()
                .Property(e => e.AddressText)
                .IsUnicode(false);

            modelBuilder.Entity<Distributor>()
                .Property(e => e.Summary)
                .IsUnicode(false);

            modelBuilder.Entity<Feedback>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Feedback>()
                .Property(e => e.Rate)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Ingredient>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Ingredient>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Ingredient>()
                .HasMany(e => e.Products)
                .WithMany(e => e.Ingredients)
                .Map(m => m.ToTable("ProductsIngredients").MapLeftKey("IngredientId").MapRightKey("ProductId"));

            modelBuilder.Entity<Product>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Recipe)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);
        }
    }
}
