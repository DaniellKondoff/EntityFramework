using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Models;

namespace Client
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var context = new MoviesContext();
            //context.Database.Initialize(true);

            //var actor1 = new Actor()
            //{
            //    FirstName = "Matthew",
            //    LastName = "McConaghey"

            //};
            //actor1.Movies.Add(context.Movies.Where(m => m.Title == "Contact").FirstOrDefault());
            //actor1.Movies.Add(context.Movies.Where(m => m.Title == "Scarface").FirstOrDefault());
            //var actor2 = new Actor()
            //{
            //    FirstName="Christian",
            //    LastName="Bale"
            //};

            //actor2.Movies.Add(context.Movies.Where(m => m.Title == "The Dark Knight").FirstOrDefault());

            //context.Actors.AddRange(new[] { actor1, actor2 });
            //context.SaveChanges();

            //context.Movies.Where(m => m.Title == "Contact").FirstOrDefault().Duration=170;
            //context.SaveChanges();

            //var movie = context.Movies.Where(m => m.Title == "Contact").FirstOrDefault();
            //movie.Genres.Add(new Genre()
            //{
            //    GenreName="Drama"
            //});

            //context.SaveChanges();

            var studio = new Studio()
            {
                Name = "Warner Bros"
            };
            context.Movies.Where(m => m.Title == "Contact").FirstOrDefault().Studio = studio;
            context.SaveChanges();

            foreach (var dir in context.Directors.ToList())
            {
                Console.WriteLine(dir.FirstName);
            }

        }
    }
}
