using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakary
{
    class Program
    {
        static void Main(string[] args)
        {
           var context = new BakaryContext();
           var products= context.Products.Where(CheckDistributor)
                .OrderBy(p=>p.Id)
                .ToList();

            products.ForEach(PrintInfo);
        }

        static void PrintInfo(Product p)
        {
            string name = p.Name;
            var distributor = p.Ingredients.FirstOrDefault().Distributor;
            string distrName = distributor.Name;
            string distrCountry = distributor.Country.Name;

            decimal? rate =p.Feedbacks.Select(f => f.Rate).Average();

            Console.WriteLine($"{name} {rate} {distrName} {distrCountry}");
        }
        static bool CheckDistributor(Product p)
        {
            var ingr = p.Ingredients
                .FirstOrDefault();
            if (ingr == null) { return false; }
            var distrId = ingr
                .DistributorId;
            return p.Ingredients.All(i => i.DistributorId == distrId);
            
        }
    }
}
