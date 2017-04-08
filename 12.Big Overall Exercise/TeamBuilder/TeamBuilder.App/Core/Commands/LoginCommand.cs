using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamBuilder.App.Utilities;
using TeamBuilder.Models;

namespace TeamBuilder.App.Core.Commands
{
    class LoginCommand
    {
        public string Exute(string[] inputArgs)
        {
            string username = inputArgs[0];
            string password = inputArgs[1];

            if (AuthenticationManager.IsAuthenticated())
            {
                throw new InvalidOperationException(Constants.ErrorMessages.LogoutFirst);
            }

            User user = AuthenticationManager.GetCurrentUserByCredentials(username, password);
            if (user==null || user.IsDeleted)
            {
                throw new ArgumentException(Constants.ErrorMessages.UserOrPasswordIsInvalid);
            }
            AuthenticationManager.Login(username, password);

            return $"User {user.Username} successfully logged in!";
        }
    }
}
