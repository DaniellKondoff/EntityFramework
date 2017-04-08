﻿using PhotoShare.Client;
using PhotoShare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoShare.Service
{
    public class SecurityService
    {
        private static User LoggedUser;

        public static void Login(string username, string password)
        {
            using (PhotoShareContext context=new PhotoShareContext())
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
    }
}
