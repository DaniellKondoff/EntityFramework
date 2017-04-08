using _07.GringotsDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.GringotsDB
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var context = new  GringotsContext();
            //context.Database.Initialize(true);

            WizardDeposit dumbledore = new WizardDeposit()
            {
                FirstName = "Albus",
                LastName = "Dumbledore",
                Age = 150,
                MagicWandCreator = "Antoich Peverell",
                MagicWandSize = 15,
                DepositStartDate = new DateTime(2016, 10, 20),
                DepositExpirationDate = new DateTime(2020, 10, 20),
                DepositAmount = 20000.24m,
                DepositCharge = 0.2,
                IsDepositExpired = false,
            };

            context.WizardDeposit.Add(dumbledore);
            context.SaveChanges();
        }
    }
}
