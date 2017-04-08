using HomeWork.Data;
using System;
using System.Globalization;
using System.Linq;


namespace HomeWork.Tasks
{
    class BooksReleasedBeforeDate
    {

        public enum EditionType
        {
            Normal,
            Promo,
            Gold
        }
        public static void GetBookBeforedate(BookContext context)
        {
            Console.Write("Enter a Date: ");
            string inputData = Console.ReadLine();
            DateTime date = DateTime.ParseExact(inputData, "dd-MM-yyyy",CultureInfo.InvariantCulture);


            //Console.WriteLine(date);
            var books = context.Books
                .Where(b => b.ReleaseDate.Value < date)
                .Select(b=>new
                {
                    b.Title,
                    b.EditionType,
                    b.Price
                });

            foreach (var book in books)
            {
                Console.WriteLine($"{book.Title} - {(EditionType)book.EditionType} - {book.Price}");
            }
        }
    }
}
