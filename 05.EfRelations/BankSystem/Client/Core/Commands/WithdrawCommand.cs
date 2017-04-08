using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Core.Commands
{
    public class WithdrawCommand
    {
        private SavingService savingService;

        public WithdrawCommand(SavingService savingService)
        {
            this.savingService = savingService;
        }

        public string Execute(string[] data)
        {
            if (data.Length != 2)
            {
                throw new ArgumentException("Invalid Input");
            }

            string accountNumber = data[0];
            decimal money = decimal.Parse(data[1]);

            if (!this.savingService.IsExist(accountNumber))
            {
                throw new ArgumentException("This account does not exist");
            }

            this.savingService.WithDraw(accountNumber, money);
            decimal currentBalance = this.savingService.GetCurrentBalance(accountNumber);

            return $"Account {accountNumber} - ${currentBalance}";
        }
    }
}
