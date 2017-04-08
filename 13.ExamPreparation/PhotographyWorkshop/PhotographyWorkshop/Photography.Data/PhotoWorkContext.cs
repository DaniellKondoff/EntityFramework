namespace Photography.Data
{
    using Configuration;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class PhotoWorkContext : DbContext
    {

        public PhotoWorkContext()
            : base("name=PhotoWorkContext")
        {
            //Database.SetInitializer(new DropCreateDatabaseAlways<PhotoWorkContext>());
        }

        public virtual DbSet<Camera> Cameras { get; set; }
        public virtual DbSet<Lens> Lenses { get; set; }
        public virtual DbSet<Accessory> Accessories { get; set; }
        public virtual DbSet<Photographer> Photographers { get; set; }
        public virtual DbSet<Workshop> Workshops { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new PhotographerConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }


}