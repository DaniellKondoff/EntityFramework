using HomeWork.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.Tasks
{
    class FindProfit
    {
        public static void GetProfit(BookContext context)
        {

            var categories = context.Categories
                .GroupBy(c => new
                {
                    categoryName = c.Name,
                    categoryProfit = c.Books.Sum(b => b.Copies * b.Price)
                })
                .OrderByDescending(g => g.Key.categoryProfit)
                .ThenBy(g => g.Key.categoryName);

            foreach (var category in categories)
            {
                Console.WriteLine($"{category.Key.categoryName} - ${category.Key.categoryProfit}");
            }

          
        }
    }
}
