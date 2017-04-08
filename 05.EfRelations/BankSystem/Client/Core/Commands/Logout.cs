using Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Core.Commands
{
    class Logout
    {
        public string Execute()
        {
            if (!SecurityService.IsAuthenticated())
            {
                throw new InvalidOperationException("You should log in first!");
            }

            User loggedUser = SecurityService.GetCurrentUser();
            SecurityService.Logout();
            return $"User {loggedUser.Username} successfully logged out";
        }
    }
}
