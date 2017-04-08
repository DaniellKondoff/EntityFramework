namespace Data.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Data.BankContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Data.BankContext context)
        {
            var user = new User()
            {
                Username = "admin",
                Password = "admin1",
                Email = "admin@.bg",

            };
            context.Users.AddOrUpdate(u => u.Username, user);
            context.SaveChanges();

            var SavingAccount1 = new SavingAccount()
            {
                AccountNumber = "nomer1",
                Balance = 1000000m,
                InterestRate=4.20m
            };
            SavingAccount1.UserId = user.Id;
            var SavingAccount2 = new SavingAccount()
            {
                AccountNumber = "nomer2",
                Balance = 9000000m,
                InterestRate = 8.20m
            };
            context.SavingAccounts.AddOrUpdate(a => a.AccountNumber, SavingAccount1, SavingAccount2);
            context.SaveChanges();

            var ChecnikngAccount1 = new ChekingAccount()
            {
                AccountNumber = "nomer1",
                Balance = 1000000m,
                Fee = 10
                
            };
            var ChecnikngAccount2 = new ChekingAccount()
            {
                AccountNumber = "nomer2",
                Balance = 9000000m,
                Fee = 8.20m
            };
            ChecnikngAccount1.UserId = user.Id;
            context.CheckingAccounts.AddOrUpdate(a => a.AccountNumber, ChecnikngAccount1, ChecnikngAccount2);
            context.SaveChanges();

            
        }
    }
}
