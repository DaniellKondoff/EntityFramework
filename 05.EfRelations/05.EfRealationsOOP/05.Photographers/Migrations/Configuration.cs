namespace Photographers.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Photographers.Data.PhotoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Photographers.Data.PhotoContext";
        }

        protected override void Seed(Photographers.Data.PhotoContext context)
        {
            Photographer dani = new Photographer()
            {
                Usename="Dani",
                Password="asd",
                Email="Dani@mail.bg",
                BirthDate=new DateTime(2005,07,20),
                RegisterDate=DateTime.Now
            };
            context.Photographers.AddOrUpdate(p => p.Usename, dani);
            context.SaveChanges();
            Picture demoPicture = new Picture()
            {
                Title="Demo",
                Caption="Demo",
                FilePath="C:\\Temp"
            };
            context.Pictures.AddOrUpdate(p=>p.Title,demoPicture);
            context.SaveChanges();

            Album RealMadrid = new Album()
            {
                Name="Real Madrid",
                BackgroundColor="White",
                isPublic=true,
  
            };
            
            context.Albums.AddOrUpdate(a => a.Name, RealMadrid);
            
            RealMadrid.Pictures.Add(demoPicture);
            context.SaveChanges();

            PhotographerAlbums ph = new PhotographerAlbums()
            {
                Photographer_Id = dani.Id,
                Album_Id = RealMadrid.Id,
                Role = Role.Owner
            };

            RealMadrid.Photographers.Add(ph);
            context.PhotographerAlbums.Add(ph);

            Tag realTag = new Tag()
            {
                Label = "#RM"
            };
            context.Tags.AddOrUpdate(t=>t.Label,realTag);
            context.SaveChanges();
            realTag.Albums.Add(RealMadrid);
            RealMadrid.Tags.Add(realTag);

            context.SaveChanges();

        }
    }
}
