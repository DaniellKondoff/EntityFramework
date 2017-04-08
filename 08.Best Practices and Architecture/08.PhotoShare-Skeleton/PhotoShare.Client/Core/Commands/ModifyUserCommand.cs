namespace PhotoShare.Client.Core.Commands
{
    using Service;
    using System;
    using Models;

    public class ModifyUserCommand
    {
        private readonly UserService userService;
        private readonly TownService townService;


        public ModifyUserCommand(UserService userService,TownService townService)
        {
            this.userService = userService;
            this.townService = townService;
        }
        // ModifyUser <username> <property> <new value>
        // For example:
        // ModifyUser <username> Password <NewPassword>
        // ModifyUser <username> BornTown <newBornTownName>
        // ModifyUser <username> CurrentTown <newCurrentTownName>
        // !!! Cannot change username
        public string Execute(string[] data)
        {
            if (!SecurityService.IsAuthenticated())
            {
                throw new InvalidOperationException("You should log in first!");
            }

            string username = data[0];
            string propertyType = data[1];
            string value = data[2];

            User u = this.userService.GetUserByUsername(username);

            if (u==null)
            {
                throw new ArgumentException($"User {username} not found!");
            }

            if (propertyType=="Password")
            {
                u.Password = value;
            }
            else if (propertyType== "BornTown")
            {
                Town t = this.townService.GetByTownName(value);
                if (t==null)
                {
                    throw new ArgumentException($"Town {value} not found!");
                }
                u.BornTown = t;
            }
            else if (propertyType== "CurrentTown")
            {
                Town t = this.townService.GetByTownName(value);
                if (t == null)
                {
                    throw new ArgumentException($"Town {value} not found!");
                }
                u.CurrentTown = t;
            }
            else
            {
                throw new ArgumentException($"Property {propertyType} not supported!");
            }

            this.userService.UpdateUser(u);
            return $"User {username} {propertyType} is {value}.";
        }
    }
}
