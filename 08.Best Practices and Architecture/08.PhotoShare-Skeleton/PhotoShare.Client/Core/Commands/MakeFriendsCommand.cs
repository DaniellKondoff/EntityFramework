namespace PhotoShare.Client.Core.Commands
{
    using Models;
    using Service;
    using System;

    public class MakeFriendsCommand
    {
        private UserService userService;

        public MakeFriendsCommand(UserService userService)
        {
            this.userService = userService;
        }
        // MakeFriends <username1> <username2>
        public string Execute(string[] data)
        {
            if (!SecurityService.IsAuthenticated())
            {
                throw new InvalidOperationException("You should log in first!");
            }

            string userName1 = data[0];
            string userName2 = data[1];

            User loggedUser = SecurityService.GetCurrentUser();

            if (loggedUser.Username!=userName1)
            {
                throw new ArgumentException($"Ivalid Credentials");
            }
            if (!this.userService.IsUserExist(userName1))
            {
                throw new ArgumentException($"{userName1} not found");
            }
            if (!this.userService.IsUserExist(userName2))
            {
                throw new ArgumentException($"{userName2} not found");
            }
            if (this.userService.UserIsFriend(userName1, userName2))
            {
                throw new InvalidOperationException($"{userName2} is already a friend to {userName1}");
            }

            this.userService.MakeFriends(userName1, userName2);
            return $"Friend {userName2} added to {userName1}";
        }
    }
}
