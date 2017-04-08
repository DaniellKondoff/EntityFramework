using HomeWork.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.Tasks
{
    class BookTitleByCatSQL
    {
        public static void GetBookTitles(BookContext context)
        {

            string[] input = Console.ReadLine().Split(' ').Select(i => i.ToLower()).ToArray();

            var books = context.Books;

            foreach (var book in books)
            {
                if (book.Categories.Any(c=>input.Contains(c.Name.ToLower())))
                {
                    Console.WriteLine(book.Title);
                }
            }
            
        }
    }
}
