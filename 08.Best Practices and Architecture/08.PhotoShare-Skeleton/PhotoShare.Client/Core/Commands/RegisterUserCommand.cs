namespace PhotoShare.Client.Core.Commands
{
    using System;
    using Service;

    public class RegisterUserCommand
    {
        // RegisterUser <username> <password> <repeat-password> <email>

        private readonly UserService service;

        public RegisterUserCommand(UserService service)
        {
            this.service = service;
        }
        public string Execute(string[] data)
        {
            if (SecurityService.IsAuthenticated())
            {
                throw new InvalidOperationException("Invalid Credentials!");
            }
            string username = data[0];
            string password = data[1];
            string repeatPassword = data[2];
            string email = data[3];

            if (password != repeatPassword)
            {
                throw new ArgumentException("Passwords do not match!");
            }

            if (this.service.IsUserExist(username))
            {
                throw new InvalidOperationException($"Username {username} is already taken!");
            }
            this.service.Add(username, password, email);

            return "User " + username + " was registered successfully!";
        }
    }
}
