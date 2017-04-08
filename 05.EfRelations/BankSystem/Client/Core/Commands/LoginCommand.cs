using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Core.Commands
{
    public class LoginCommand
    {

        public string Execute(string[] data)
        {
            string userName = data[0];
            string password = data[1];

            if (SecurityService.IsAuthenticated())
            {
                throw new InvalidOperationException("You should logout first!");
            }
            SecurityService.Login(userName, password);

            if (SecurityService.GetCurrentUser() == null)
            {
                throw new ArgumentException("Invalid username or password!");
            }

            return $"User {userName} successfully logged in!";
        }
    }
}
