using HomeWork.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.Tasks
{
    public class AuthorsSearch
    {
        public static void GetAuthors(BookContext context)
        {
            Console.Write("Enter an input: ");
            string input = Console.ReadLine();

            var authors = context.Authors.Where(a => a.FirstName.EndsWith(input));

            foreach (var author in authors)
            {
                Console.WriteLine($"{author.FirstName} {author.LastName}");
            }
        }
    }
}
