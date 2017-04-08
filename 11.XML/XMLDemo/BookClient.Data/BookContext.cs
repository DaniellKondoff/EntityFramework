namespace BookClient.Data
{
    using BookCatalog.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class BookContext : DbContext
    {
        public BookContext()
            : base("name=BookContext")
        {
        }


        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }

    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}