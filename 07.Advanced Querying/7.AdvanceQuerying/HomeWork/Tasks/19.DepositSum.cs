using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.Tasks
{
    class DepositSum
    {
        public static void GetCount(GringotsContext context)
        {
            var depositGroups = context.WizzardDeposits.Where(w => w.MagicWandCreator == "Ollivander family")
                .GroupBy(w => w.DepositGroup)

                .Select(w => new
                {
                    depositGroup = w.Key,
                    TotalDepositSum = w.Sum(d => d.DepositAmount)
                });
                

            foreach (var deposit in depositGroups)
            {
                Console.WriteLine($"{deposit.depositGroup} - {deposit.TotalDepositSum}");
            }
        }
    }
}
