using EntityFramework.Extensions;
using HomeWork.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.Tasks
{
    class RemoveBooks
    {
        public static void GetCount(BookContext context)
        {
            var booksCount = context.Books.Where(b => b.Copies < 4200);
            Console.WriteLine($"{booksCount.Count()} book were deleted");
            context.Books.Where(b => b.Copies < 4200).Delete();
        }
    }
}
