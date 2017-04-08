using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Core.Commands
{
    public class RegisterCommand
    {
        private UserService userService;
        public RegisterCommand(UserService userService)
        {
            this.userService = userService;
        }
        public string Execute(string[] data)
        {
            string userName = data[0];
            string password = data[1];
            string email = data[2];

            if(this.userService.IsUserExist(userName))
            {
                throw new ArgumentException("The user already exist");
            }

            this.userService.AddUser(userName, password, email);

            return $"{userName} was registered in the system";
        }
    }
}
