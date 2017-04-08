using HomeWork.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HomeWork.Tasks
{
    public class NotReleasedBooks
    {
        public static void GetNotReleasedBooks(BookContext context)
        {
            Console.Write("Enter a date: ");
            int inputData = int.Parse(Console.ReadLine());

            var books = context.Books
                .Where(b => b.ReleaseDate.Value.Year != inputData)
                .OrderBy(b => b.Id)
                .Select(b => b.Title);

            foreach (var book in books)
            {
                Console.WriteLine(book);
            }
        }
    }
}
