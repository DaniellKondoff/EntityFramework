namespace Photographers.Data
{
    using Migrations;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class PhotoContext : DbContext
    {

        public PhotoContext()
            : base("name=PhotoContext")
        {
            //Database.SetInitializer(new DropCreateDatabaseAlways<PhotoContext>());
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<PhotoContext, Configuration>());
        }

        public virtual DbSet<Photographer> Photographers { get; set; }

        public virtual DbSet<Album> Albums { get; set; }

        public virtual DbSet<Picture> Pictures { get; set; }

        public virtual DbSet<Tag> Tags { get; set; }

        public virtual DbSet<PhotographerAlbums> PhotographerAlbums { get; set; }

    }

}