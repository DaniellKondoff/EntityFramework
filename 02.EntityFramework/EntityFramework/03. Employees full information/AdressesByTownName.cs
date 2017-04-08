using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Employees_full_information
{
    class AdressesByTownName
    {
        public static void GetAdressesByTownName(SoftUniContext context)
        {
            var adrs = context.Addresses
                .OrderByDescending(a => a.Employees.Count)
                .ThenBy(a=>a.Town.Name)
                .Take(10)
                .ToList();

            foreach (var adr in adrs)
            {
                Console.WriteLine($"{adr.AddressText}, {adr.Town.Name} - {adr.Employees.Count} employees");
            }
        }
    }
}
