namespace PhotoShare.Client.Core.Commands
{
    using Models;
    using Service;
    using System;
    using System.Linq;

    public class PrintFriendsListCommand 
    {
        private UserService userService;
        public PrintFriendsListCommand(UserService userService)
        {
            this.userService = userService;
        }

        // PrintFriendsList <username>
        public string Execute(string[] data)
        {
            string username = data[0];

            if (!this.userService.IsUserExist(username))
            {
                throw new ArgumentException($"User {username} not found!");
            }

            User user = this.userService.ListAllFriends(username);

            if (user.Friends.Count==0)
            {
                throw new ArgumentException("No friends for this user.");
            }
            string friends = "Friends:";
            foreach (var item in user.Friends)
            {
                friends += "\n" + item.Username;
            }
                       
            return friends;
        }
    }
}
