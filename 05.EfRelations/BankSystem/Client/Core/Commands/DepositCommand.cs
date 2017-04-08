using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Core.Commands
{
    public class DepositCommand
    {
        private SavingService savingService;
        public DepositCommand(SavingService savingService)
        {
            this.savingService = savingService;
        }
        public string Execute(string[] data)
        {

            if (data.Length !=2)
            {
                throw new ArgumentException("Invalid Input");
            }
            string accountNumber = data[0];
            decimal money = decimal.Parse(data[1]);

            if (!this.savingService.IsExist(accountNumber))
            {
                throw new ArgumentException("This account does not exist");
            }
            this.savingService.AddDeposit(accountNumber, money);
            decimal currentBalance =this.savingService.GetCurrentBalance(accountNumber);

            //TODO CheckingAccount
            return $"Account {accountNumber} - ${currentBalance}";
        }
    }
}
