using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.GetUserByEmail
{
    class StartUp
    {
        static void Main(string[] args)
        {
           var context = new UserContext();

            Console.Write("Enter input: ");
            string input = Console.ReadLine();
            var users = context.Users
                 .Where(u => u.Email.EndsWith(input))
                 .Select(u => new { u.Username, u.Email })
                 .ToList();

            foreach (var u in users)
            {
                Console.WriteLine($"{u.Username} {u.Email}");
            }

        }
    }
}
