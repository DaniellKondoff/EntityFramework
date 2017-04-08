using HomeWork.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.Tasks
{
    class MostRecentBooks
    {
        public static void GetCount(BookContext context)
        {
          

            var categoryRecentBooks = context.Categories
                .Where(c => c.Books.Count > 35)
                .Select(category => new
                {
                    CategoryName = category.Name,
                    TotalBookCount = category.Books.Count,
                    RecentBooks = category.Books
                    .OrderByDescending(c => c.ReleaseDate)
                    .ThenBy(c => c.Title)
                    .Select(b => new
                    {
                        Title = b.Title,
                        Releasedate = b.ReleaseDate
                    }).Take(3).Distinct()
                }).OrderByDescending(catt=>catt.TotalBookCount);

            foreach (var categoryRecentBook in categoryRecentBooks)
            {
                Console.WriteLine($"--{categoryRecentBook.CategoryName}: {categoryRecentBook.TotalBookCount} books");
                foreach (var book in categoryRecentBook.RecentBooks)
                {
                    Console.WriteLine($"{book.Title} ({book.Releasedate.Value.Year})");
                }
            }



        }
    }
}
