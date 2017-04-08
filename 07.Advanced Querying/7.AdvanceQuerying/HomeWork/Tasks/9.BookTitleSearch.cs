using HomeWork.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.Tasks
{
    public class BooksTitleSearch
    {
        public static void GetBooks(BookContext context)
        {
            string input = Console.ReadLine().ToLower();

            var books = context.Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(input))
                .OrderBy(b=>b.Id)
                .Select(b=>b.Title);

            foreach (var book in books)
            {
                Console.WriteLine(book);
            }

        }
    }
}
