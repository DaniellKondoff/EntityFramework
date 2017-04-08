using System;
using System.Collections.Generic;
using System.Linq;
using BookShopSystem.Models;
using BookShopSystem.Client;
using BookShopSystem.Enumeration;
using System.Data.Entity;
using BookShopSystem.HomeworkQuerung;

namespace Client.BookShopSystem
{
    class BookShopMain
    {
        static void Main()
        {
            var context = new BookShopContext();
            context.Database.Initialize(true);

            var books = context.Books
                .Take(3)
                .ToList();
            //books[0].RelatedBooks.Add(books[1]);
            //books[1].RelatedBooks.Add(books[0]);
            //books[0].RelatedBooks.Add(books[2]);
            //books[2].RelatedBooks.Add(books[0]);

            //context.SaveChanges();

            foreach (var book in books)
            {
                Console.WriteLine($"--{book.Title}");

                foreach (var relBook in book.RelatedBooks)
                {
                    Console.WriteLine(relBook.Title);
                }
            }





        }
    }
}
