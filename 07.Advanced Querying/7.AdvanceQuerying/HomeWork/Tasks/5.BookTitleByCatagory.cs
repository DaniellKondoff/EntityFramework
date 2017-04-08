using HomeWork.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.Tasks
{
    public class BookTitleByCatagory
    {
        public static void GetBookTitles(BookContext context)
        {
            string[] input = Console.ReadLine().Split(' ').ToArray();

            var result = new HashSet<string>();

            var books = context.Books.SelectMany(b => b.Categories.SelectMany(c => c.Books)).OrderBy(b=>b.Id);

            for (int i = 0; i < input.Length; i++)
            {
                foreach (var book in books)
                {
                   
                    foreach (var bc in book.Categories)
                    {
                        if (bc.Name.ToLower() == input[i].ToLower())
                        {
                            result.Add(book.Title);
                        }
                    }
                }
            }

            foreach (var item in result)
            {
                Console.WriteLine(item);
               
            }
            
        }
    }
}

