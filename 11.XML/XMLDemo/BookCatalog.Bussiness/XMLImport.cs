using BookCatalog.Bussiness.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BookCatalog.Bussiness
{
    public static class XMLImport
    {
        public static void ImportBooks(string fileName)
        {
            XDocument xmlDoc = XDocument.Load(fileName);

            var books = xmlDoc.Root.Elements();

            foreach (var book in books)
            {

            }
        }

        public static BookDTO ParseBook(XElement book)
        {

        }

    }
}
