using HomeWork.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.Tasks
{
    class CountBooks
    {
        public static void GetCount(BookContext context)
        {
            int input = int.Parse(Console.ReadLine());

            var bookCount = context.Books
                .Where(b => b.Title.Length > input).Count();

            Console.WriteLine(bookCount);
            Console.WriteLine($"There are {bookCount} books with longer title than {input} symbols");
        }
    }
}
