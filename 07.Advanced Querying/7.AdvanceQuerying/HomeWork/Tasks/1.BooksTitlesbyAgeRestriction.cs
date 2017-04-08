using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeWork.Data;
using HomeWork.Models;

namespace HomeWork.Tasks
{
    class BooksTitlesbyAgeRestriction
    {
        public static void BookByAge(BookContext context)
        {
            Console.Write("Enter Age Restriction: ");
            string input = Console.ReadLine().ToLower();
            ICollection<string> books = new List<string>();

            switch (input)
            {
                case "minor":
                    books = context.Books.Where(b => b.AgeRestriction.Equals(0)).Select(b => b.Title).ToList();
                    break;
                case "teen":
                    books = context.Books.Where(b => b.AgeRestriction.Equals(1)).Select(b => b.Title).ToList();
                    break;
                case "adult":
                    books = context.Books.Where(b => b.AgeRestriction.Equals(2)).Select(b => b.Title).ToList();
                    break;
                default:
                    throw new ArgumentException("Invalid Input");
            }

            foreach (var book in books)
            {
                Console.WriteLine(book);
            }

        }
    }
}
