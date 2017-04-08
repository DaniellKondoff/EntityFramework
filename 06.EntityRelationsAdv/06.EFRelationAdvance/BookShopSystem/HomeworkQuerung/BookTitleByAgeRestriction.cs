using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShopSystem.Client;
using BookShopSystem.Models;

namespace BookShopSystem.HomeworkQuerung
{
    class BookTitleByAgeRestriction
    {
        public static void BookByAge(BookShopContext context)
        {
            Console.Write("Enter Age Restriction: ");
            string input = Console.ReadLine().ToLower();
            ICollection<string> books = new List<string>();

            switch (input)
            {
                case "minor":
                    books = context.Books.Where(b => b.AgeRestriction == Enumeration.AgeRestriction.Minor).Select(b => b.Title).ToList();
                    break;
                case "teen":
                    books = context.Books.Where(b => b.AgeRestriction == Enumeration.AgeRestriction.Teen).Select(b => b.Title).ToList();
                    break;
                case "adult":
                    books = context.Books.Where(b => b.AgeRestriction == Enumeration.AgeRestriction.Adult).Select(b => b.Title).ToList();
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
