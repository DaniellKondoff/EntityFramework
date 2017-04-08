using EntityFramework.Extensions;
using HomeWork.Data;
using HomeWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.Tasks
{
    class IncreaseBookCopies
    {
        public static void GetCount(BookContext context)
        {

            string inputData = "06 Jun 2013";
            int countToAdd = 44;

            DateTime date = DateTime.Parse(inputData);

            var books = context.Books.Where(b => b.ReleaseDate > date);
            Console.WriteLine($"Output: {books.Count()*countToAdd}");

            context.Books.Update(books, book => new Book() { Copies = book.Copies + countToAdd });
            context.SaveChanges();



        }
    }
}
