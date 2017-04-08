using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Employees_full_information
{
    class DeleteTown
    {
        public static void GetDeleteTown(SoftUniContext context)
        {
            Console.Write("Pease Enter a Town: ");
            string townName = Console.ReadLine();
           

            var town = context.Towns.Where(t=>t.Name==townName).First();
                

            var addresess = context.Addresses
                .Where(a => a.Town.Name == townName).ToList();
                


            foreach (var adr in addresess)
            {
                foreach (var emp in adr.Employees)
                {
                    emp.AddressID = null;
                }
                context.Addresses.Remove(adr);
                context.SaveChanges();       
            }

            context.Towns.Remove(town);
            context.SaveChanges();

            if (addresess.Count==1)
            {
                Console.WriteLine($"1 address in {town.Name} was deleted");
            }
            else
            {
                Console.WriteLine($"{addresess.Count} addresses in {town.Name} were deleted");
            }



        }
    }
}
