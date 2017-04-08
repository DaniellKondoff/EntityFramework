using HomeWork.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.Tasks
{
   public class StoredProcedure
    {
       public static void GetBooksCount(BookContext context)
        {
            string[] nameInput = Console.ReadLine().Split(' ').ToArray();

            var count = context.Database.SqlQuery<int>("exec usp_BookCount {0},{1}", nameInput[0], nameInput[1]).First();
            Console.WriteLine(count);
        }
       
    }
}
