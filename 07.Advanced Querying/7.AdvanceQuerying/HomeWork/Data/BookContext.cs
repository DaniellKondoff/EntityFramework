namespace HomeWork.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Models;

    public partial class BookContext : DbContext
    {
        public BookContext()
            : base("name=BookContext")
        {
        }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasMany(e => e.Categories)
                .WithMany(e => e.Books)
                .Map(m => m.ToTable("CategoryBooks"));

            modelBuilder.Entity<Book>()
                .HasMany(e => e.Books1)
                .WithMany(e => e.Books)
                .Map(m => m.ToTable("RelatedBooks").MapLeftKey("BookId").MapRightKey("RelatedId"));
        }
    }
}
