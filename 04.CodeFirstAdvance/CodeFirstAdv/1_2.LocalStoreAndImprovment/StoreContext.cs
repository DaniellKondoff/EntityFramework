namespace _1_2.LocalStoreAndImprovment
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Model;

    public class StoreContext : DbContext
    {

        public StoreContext()
            : base("name=StoreContext")
        {
            Database.SetInitializer(new InitializeAndSeed());
        }
        public virtual DbSet<Product> Products { get; set; }

    }


}