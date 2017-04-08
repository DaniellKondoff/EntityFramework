using System;

namespace App.Client.Services
{
    public class Authenticator
    {
        private static Authenticator instance;
        private string currentUser;
        private Authenticator()
        {
        }
        public static Authenticator Instance
        {
            get
            {
                if (instance == null) instance = new Authenticator();
                return instance;
            }
        }

        public void LogIn(string user)
        {
            this.currentUser = user;
        }
        public void LogOut()
        {
            this.currentUser = null;
        }

        public string Current
        {
            get
            {
                return this.currentUser;
            }
        }
    }

}
