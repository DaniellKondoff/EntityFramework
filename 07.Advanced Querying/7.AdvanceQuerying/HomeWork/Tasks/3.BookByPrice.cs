using HomeWork.Data;
using HomeWork.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.Tasks
{
    class BookByPrice
    {
        public static void GetBookByPrice(BookContext context)
        {
            var books = context.Books
                .Where(b => b.Price < 5 || b.Price > 40)
                .OrderBy(b => b.Id)
                .Select(b => new BookByPriceModel
                {
                    Title=b.Title,
                    Price=b.Price
                });


            foreach (var book in books)
            {
                Console.WriteLine($"{book.Title} - ${book.Price}");
            }
        }
    }
}
