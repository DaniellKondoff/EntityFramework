using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.Tasks
{
    class DepositFilter
    {
        public static void GetDepositFilter(GringotsContext context)
        {
            var depositGroups = context.WizzardDeposits
                .Where(w => w.MagicWandCreator == "Ollivander family")
                .GroupBy(w => w.DepositGroup)

                .Select(w => new
                {
                    depositGroup = w.Key,
                    TotalDepositSum = w.Sum(d => d.DepositAmount)
                })
                .Where(d=>d.TotalDepositSum< 150000)
                .OrderByDescending(d=>d.TotalDepositSum);


            foreach (var deposit in depositGroups)
            {
                Console.WriteLine($"{deposit.depositGroup} - {deposit.TotalDepositSum}");
            }
        }
    }
}
