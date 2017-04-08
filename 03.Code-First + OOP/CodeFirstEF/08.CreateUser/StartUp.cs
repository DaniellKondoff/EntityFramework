using _08.CreateUser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.CreateUser
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var context = new UserContext();

            context.Database.Initialize(true);

            var ivo = new User
            {
                Username = "Ivo Ivov",
                Password = "1!Ivoo",
                Email = "ivo@abv.bg",
                RegisteredOn = new DateTime(1985, 10, 09),
                LastTimeLoggedIn = new DateTime(2010, 06, 01),
                Age = 31,
                IsDeleted = false,
            };

            context.User.Add(ivo);
            context.SaveChanges();

            //11.Get user by email Provider
            //Console.Write("Enter input: ");
            //string input = Console.ReadLine();
            //var users = context.User
            //     .Where(u => u.Email.EndsWith(input))
            //     .Select(u => new { u.Username, u.Email })
            //     .ToList();

            //foreach (var u in users)
            //{
            //    Console.WriteLine($"{u.Username} {u.Email}");
            //}
        }
    }
}
