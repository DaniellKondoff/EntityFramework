using HomeWork.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.Tasks
{
    class TotalBookCopies
    {
        public static void GetCount(BookContext context)
        {
            var books = context.Books
                 .GroupBy(b => b.Author)
                 .Select(b => new
                 {
                     Author = b.Key,
                     Copies = b.Sum(c => c.Copies)
                 })
                 .OrderByDescending(c => c.Copies)
                 .ToList();

            foreach (var book in books)
            {
                Console.WriteLine($"{book.Author.FirstName} {book.Author.LastName} - {book.Copies}");
            }

            Console.WriteLine(books);
        }
    }
}
