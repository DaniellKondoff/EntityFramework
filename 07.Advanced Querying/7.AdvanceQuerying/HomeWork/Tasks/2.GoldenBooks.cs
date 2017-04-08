using HomeWork.Data;
using HomeWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.Tasks
{
    public class GoldenBooks
    {
        public static void GetGoldenBooks(BookContext context)
        {
            var books = context.Books
                .Where(b => b.EditionType.Equals(2) && b.Copies <= 5000)
                .OrderBy(b=>b.Id)
                .Select(b => b.Title);


            foreach (var book in books)
            {
                Console.WriteLine(book);
            }
        }
    }
}
