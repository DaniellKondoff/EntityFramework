using Client.Core.Utilities;
using Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Core.Commands
{
    class AddSavingAccountCommand
    {
        private SavingService savingService;
        public AddSavingAccountCommand(SavingService savingAccount)
        {
            this.savingService = savingAccount;
        }

        public string Execute(string[] data)
        {
            string accountName = AccounGenerator.GenereteCode();
            decimal balance = decimal.Parse(data[0]);
            decimal rate = decimal.Parse(data[1]);

            if (!SecurityService.IsAuthenticated())
            {
                throw new Exception("LogIn first");
            }

            User loggedUser = SecurityService.GetCurrentUser();

            this.savingService.addSavingAccount(accountName, balance, rate, loggedUser.Username);

            return $"Succesfully added account with number {accountName}";
        }
    }
}
