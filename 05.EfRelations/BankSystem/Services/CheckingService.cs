using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CheckingService
    {
        public bool IsExist(string accountNumber)
        {
            using (BankContext context = new BankContext())
            {
                return context.CheckingAccounts.Any(a => a.AccountNumber == accountNumber);
            }
        }

        public void DeductFee(string accountNumber)
        {
            using(BankContext context = new BankContext())
            {
                var accunt = context.CheckingAccounts.SingleOrDefault(a => a.AccountNumber == accountNumber);
                accunt.Balance -= accunt.Fee;
                context.SaveChanges();
            }
        }

        public decimal GetCurrentBalance(string accountNumber)
        {
            using (BankContext context = new BankContext())
            {
                var account = context.CheckingAccounts.SingleOrDefault(a => a.AccountNumber == accountNumber);
                if (account != null)
                {
                    return account.Balance;
                }
            }
            return 0;
        }
    }
}
