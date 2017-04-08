using HomeWork.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeWork.Tasks;

namespace HomeWork
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var context = new BookContext();
            var softUniCtx= new SoftUniContext();
            var gringotsCtx = new GringotsContext();
            //BooksTitlesbyAgeRestriction.BookByAge(context);
            //GoldenBooks.GetGoldenBooks(context);
            //BookByPrice.GetBookByPrice(context);
            //NotReleasedBooks.GetNotReleasedBooks(context);
            //BookTitleByCatagory.GetBookTitles(context);
            //BooksReleasedBeforeDate.GetBookBeforedate(context);
            //AuthorsSearch.GetAuthors(context);
            //BookSearch.GetBooks(context);
            //BooksTitleSearch.GetBooks(context);
            //CountBooks.GetCount(context);
            //TotalBookCopies.GetCount(context);
            //FindProfit.GetProfit(context);
            //BookTitleByCatSQL.GetBookTitles(context);
            //MostRecentBooks.GetCount(context);
            //IncreaseBookCopies.GetCount(context);
            //RemoveBooks.GetCount(context);
            //EmpMaxSalary.GetMaxSalary(softUniCtx);
            //DepositSum.GetCount(gringotsCtx);
            //DepositFilter.GetDepositFilter(gringotsCtx);
            //StoredProcedure.GetBooksCount(context);
            //CallStorePROC.CallProc(softUniCtx);

        }
    }
}
