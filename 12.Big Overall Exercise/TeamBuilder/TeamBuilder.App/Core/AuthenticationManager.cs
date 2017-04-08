using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamBuilder.App.Utilities;
using TeamBuilder.Data;
using TeamBuilder.Models;

namespace TeamBuilder.App.Core
{
    public static class AuthenticationManager
    {
        private static User LoggedUser;

        public static void Authorize()
        {
            if (LoggedUser == null)
            {
                throw new InvalidOperationException(Constants.ErrorMessages.LoginFirst);
            }
        }


        public static void Login(string username, string password)
        {
            using (TeamBuilderContext context = new TeamBuilderContext())
            {
                User user = context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
                LoggedUser = user;
            }
        }

        public static void Logout()
        {
            LoggedUser = null;
        }

        public static bool IsAuthenticated()
        {
            return LoggedUser != null;
        }

        public static User GetCurrentUser()
        {
            return LoggedUser;
        }

        public static User GetCurrentUserByCredentials(string username, string password)
        {
            using (TeamBuilderContext context = new TeamBuilderContext())
            {
               return context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);               
            }
        }
    }
}
