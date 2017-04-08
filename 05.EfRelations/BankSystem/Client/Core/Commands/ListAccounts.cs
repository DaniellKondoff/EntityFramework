using Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Core.Commands
{
    public class ListAccounts
    {
        private CheckingService checkingService;
        private SavingService savingService;

        public ListAccounts(SavingService savingService, CheckingService checkingService)
        {
            this.savingService = savingService;
            this.checkingService = checkingService;
        }

        public string Execute()
        {
            StringBuilder builder = new StringBuilder();


            User user = SecurityService.GetCurrentUser();
            this.savingService.ListAllAccounts(builder);
            return builder.ToString().Trim();
        }
    }
}
