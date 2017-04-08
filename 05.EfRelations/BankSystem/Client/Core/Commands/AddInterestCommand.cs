using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Core.Commands
{
   public class AddInterestCommand
    {
        private SavingService savingService;
        public AddInterestCommand(SavingService savingService)
        {
            this.savingService = savingService;
        }



        public string Execute(string[] data)
        {
            if (data.Length !=1)
            {
                throw new ArgumentException("Invalid Input");
            }
            string accountNumber = data[0];

            if (!this.savingService.IsExist(accountNumber))
            {
                throw new ArgumentException("This account does not exist");
            }

            this.savingService.AddInterest(accountNumber);
            decimal currentBalance = this.savingService.GetCurrentBalance(accountNumber);


            return $"Added interest to {accountNumber}. Current balance: {currentBalance}";
        }
    }
}
