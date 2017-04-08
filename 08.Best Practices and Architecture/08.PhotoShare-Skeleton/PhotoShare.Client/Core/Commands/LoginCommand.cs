namespace PhotoShare.Client.Core.Commands
{
    using Service;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class LoginCommand
    {


        public string Execute(string[] data)
        {
            string username = data[0];
            string password = data[1];

            if (data.Length !=2)
            {
                throw new ArgumentException("Input is not valid!");
            }
            if (SecurityService.IsAuthenticated())
            {
                throw new InvalidOperationException("You should logout first!");
            }

            SecurityService.Login(username, password);

            if (SecurityService.GetCurrentUser() == null)
            {
                throw new ArgumentException("Invalid username or password!");
            }

            return $"User {username} successfully logged in!";
        }
    }
}
