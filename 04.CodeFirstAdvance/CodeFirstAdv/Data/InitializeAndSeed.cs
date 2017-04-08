using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Models;

namespace Data
{
   public class InitializeAndSeed : DropCreateDatabaseAlways<MoviesContext>
    {
        protected override void Seed(MoviesContext context)
        {
            //var nolan = new Director()
            //{
            //    FirstName = "FirstName",
            //    LastName = "SecondName"
            //};
            //var zemeckis = new Director()
            //{
            //    FirstName="Rpbert",
            //    LastName="Zemeckis"
            //};

            //var movie1 = new Movie()
            //{
            //    Title = "Scarface",
            //    Genre = "Classic",
            //    Rating = 9.9f,
            //    ReleaseYear = 1978,
            //    Director = nolan

            //};

            //var movie2 = new Movie()
            //{
            //    Title = "The Dark Knight",
            //    Genre = "Triller",
            //    Rating = 8.4f,
            //    ReleaseYear = 2012,
            //    Director = nolan
            //};

            //var movie3 = new Movie()
            //{
            //    Title = "Contact",
            //    Genre = "Mistery",
            //    Rating = 7.6f,
            //    ReleaseYear = 1997,
            //    Director = zemeckis

            //};

            //context.Movies.Add(movie1);
            //context.Movies.Add(movie2);
            //context.Movies.Add(movie3);


            //context.SaveChanges();
            //base.Seed(context);
        }
    }
}
