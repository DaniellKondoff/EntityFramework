using Client.Core.Commands;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Core
{
    public class CommandDispatcher
    {
        public string DispatchCommand(string[] commandParameters)
        {
            string commandName = commandParameters[0];
            commandParameters = commandParameters.Skip(1).ToArray();
            string result = string.Empty;
            SavingService savingService = new SavingService();
            CheckingService checkingService = new CheckingService();
            UserService userService = new UserService();
          

            switch (commandName)
            {
                case "Exit":
                    ExitCommand exit = new ExitCommand();
                    result = exit.Execute();
                    break;
                case "Deposit":
                    DepositCommand deposit = new DepositCommand(savingService);
                    result = deposit.Execute(commandParameters);
                    break;
                case "Withdraw":
                    WithdrawCommand withdeow = new WithdrawCommand(savingService);
                    result = withdeow.Execute(commandParameters);
                    break;
                case "AddInterest":
                    AddInterestCommand addInterest = new AddInterestCommand(savingService);
                    result = addInterest.Execute(commandParameters);
                    break;
                case "DeductFee":
                    DeductCommand deduct = new DeductCommand(checkingService);
                    result = deduct.Execute(commandParameters);
                    break;
                case "Register":
                    RegisterCommand register = new RegisterCommand(userService);
                    result = register.Execute(commandParameters);
                    break;
                case "Login":
                    LoginCommand login = new LoginCommand();
                    result = login.Execute(commandParameters);
                    break;
                case "Logout":
                    Logout logout = new Logout();
                    result = logout.Execute();
                    break;
                case "AddSavingAccount":
                    AddSavingAccountCommand addAccount = new AddSavingAccountCommand(savingService);
                    result = addAccount.Execute(commandParameters);
                    break;
                case "ListAccounts":
                    ListAccounts listAccounts = new ListAccounts(savingService,checkingService);
                    result = listAccounts.Execute();
                    break;
            }
            return result;
        }
    }
}
