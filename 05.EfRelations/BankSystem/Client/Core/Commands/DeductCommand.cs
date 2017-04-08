using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Core.Commands
{
    public class DeductCommand
    {
        private CheckingService checkingService;
        public DeductCommand(CheckingService checkingService)
        {
            this.checkingService = checkingService;
        }

        public string Execute(string[] data)
        {
            if (data.Length != 1)
            {
                throw new ArgumentException("Invalid Input");
            }
            string accountNumber = data[0];

            if (!this.checkingService.IsExist(accountNumber))
            {
                throw new ArgumentException("This account does not exist");
            }

            this.checkingService.DeductFee(accountNumber);
            decimal currentBalance = this.checkingService.GetCurrentBalance(accountNumber);

            return $"Deducted fee of {accountNumber}. Current balance: {currentBalance}";
        }
    }
}
