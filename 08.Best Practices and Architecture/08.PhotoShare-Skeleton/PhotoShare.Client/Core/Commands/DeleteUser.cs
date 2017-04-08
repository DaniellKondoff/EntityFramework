namespace PhotoShare.Client.Core.Commands
{
    using Models;
    using Service;
    using System;
    using System.Linq;

    public class DeleteUser
    {
        private  UserService userService;
        public DeleteUser(UserService userService)
        {
            this.userService = userService;
        }

        // DeleteUser <username>
        public string Execute(string[] data)
        {
            if (!SecurityService.IsAuthenticated())
            {
                throw new InvalidOperationException("You should log in first!");
            }
            string username = data[0];

            User loggedUser = SecurityService.GetCurrentUser();
            if (loggedUser.Username!=username)
            {
                throw new InvalidOperationException("Invalid credentials");
            }
            if (!this.userService.IsUserExist(username))
            {
                throw new ArgumentException($"User with {username} was not found!");
            }
            if (this.userService.IsUserDeleted(username))
            {
                throw new ArgumentException($"User with {username} is alredy deleted!");
            }
            this.userService.Remove(username);

            return $"User {username} was deleted from the database!";
        }
    }
}
