using System;
using System.Collections.Generic;
using System.Linq;
using Data;
using SqlProviderServices = System.Data.Entity.SqlServer.SqlProviderServices;
using Models;
using System.Text;

namespace Services
{
    public class SavingService
    {
        
        public  void AddDeposit(string accountNumber, decimal money)
        {        
            using (BankContext context=new BankContext())
            {
                var account = context.SavingAccounts.SingleOrDefault(a => a.AccountNumber == accountNumber);

                if (account != null)
                {
                    account.Balance += money;
                    context.SaveChanges();                   
                }
            }
        }

        public void ListAllAccounts(StringBuilder builder)
        {
            using (BankContext context=new BankContext())
            {
                User user = context.Users.Attach(SecurityService.GetCurrentUser());
                builder.AppendLine("Saving Accounts:");
                foreach (SavingAccount userSavingAccount in user.SavingAccounts)
                {
                    builder.AppendLine($"--{userSavingAccount.AccountNumber} {userSavingAccount.Balance}");
                }
            }
           
        }

        public void WithDraw(string accountNumber, decimal money)
        {
            using (BankContext context = new BankContext())
            {
                var account = context.SavingAccounts.SingleOrDefault(a => a.AccountNumber == accountNumber);

                if (account != null)
                {
                    account.Balance -= money;
                    context.SaveChanges();
                }
            }
        }

        public void addSavingAccount(string accountName, decimal balance, decimal rate, string username)
        {
            using (BankContext context = new BankContext())
            {
                var user = context.Users.SingleOrDefault(u => u.Username == username);
                var account = new SavingAccount()
                {
                    AccountNumber=accountName,
                    Balance=balance,
                    InterestRate=rate,
                    UserId=user.Id
                };
                context.SavingAccounts.Add(account);
                context.SaveChanges();
            }
        }

        public void AddInterest(string accountNumber)
        {
            using (BankContext context = new BankContext())
            {
                var account = context.SavingAccounts.SingleOrDefault(a => a.AccountNumber == accountNumber);

                if (account != null)
                {
                    account.Balance += account.Balance * account.InterestRate;
                    context.SaveChanges();
                }
            }
        }

        public  decimal GetCurrentBalance(string accountNumber)
        {
            using(BankContext context = new BankContext())
            {
                var account = context.SavingAccounts.SingleOrDefault(a => a.AccountNumber == accountNumber);
                if (account != null)
                {
                    return account.Balance;
                }
            }
            return 0;
        }

        public bool IsExist(string accountNumber)
        {
            using (BankContext context = new BankContext())
            {
                return context.SavingAccounts.Any(a => a.AccountNumber == accountNumber);
            }
        }
    }
}
