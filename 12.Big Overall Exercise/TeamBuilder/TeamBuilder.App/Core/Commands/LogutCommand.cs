using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamBuilder.App.Utilities;
using TeamBuilder.Models;

namespace TeamBuilder.App.Core.Commands
{
    public class LogutCommand
    {
        public string Execute(string[] inputArgs)
        {
            Check.CheckLength(0, inputArgs);
            AuthenticationManager.Authorize();
            User CurrentUser = AuthenticationManager.GetCurrentUser();
            AuthenticationManager.Logout();

            return $"User {CurrentUser.Username} successfully logged out!";
        }
    }
}
