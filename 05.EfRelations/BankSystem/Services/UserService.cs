using Data;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class UserService
    {
        public bool IsUserExist(string userName)
        {
            using (BankContext context = new BankContext())
            {
                return context.Users.Any(u => u.Username == userName);
            }
        }

        public void AddUser(string userName, string password, string email)
        {
            var user = new User()
            {
                Username = userName,
                Password = password,
                Email = email
            };
            using (BankContext context = new BankContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
        }
    }
}
