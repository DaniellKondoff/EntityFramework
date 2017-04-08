using PhotoShare.Models;
using PhotoShare.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoShare.Client.Core.Commands
{
    public class LogoutCommand
    {
        public string Execute()
        {
            if (!SecurityService.IsAuthenticated() )
            {
                throw new InvalidOperationException("You should log in first!");
            }

            User user = SecurityService.GetCurrentUser();
            SecurityService.Logout();

            return $"User {user.Username} successfully logged out!";
        }
    }
}
