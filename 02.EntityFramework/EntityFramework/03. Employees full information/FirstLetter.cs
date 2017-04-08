using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Employees_full_information
{
    class FirstLetter
    {
        public static void GetFirstName(GringottsContext context)
        {
            var wizards = context.WizzardDeposits
                .Where(w => w.DepositGroup == "Troll Chest")
                .Select(w => w.FirstName.Substring(0, 1))
                .Distinct()
                .OrderBy(w => w);

            foreach (var w in wizards)
            {
                Console.WriteLine(w);
            }

        }
    }
}
