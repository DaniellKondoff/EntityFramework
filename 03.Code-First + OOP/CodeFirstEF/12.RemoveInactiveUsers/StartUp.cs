using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.RemoveInactiveUsers
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var context = new UserContext();

            Console.Write("Enter a date: ");
            string inputData = Console.ReadLine();
            DateTime date= Convert.ToDateTime(inputData);
            
            var users = context.Users.Where(u => u.LastTimeLoggedIn < date);
            int afectedUsers = users.Count();

            foreach (var u in users)
            {
                u.IsDeleted = true;
                context.Users.Remove(u);
            }
            if (afectedUsers!=0)
            {
                Console.WriteLine($"{afectedUsers} users have been deleted");

            }
            else
            {
                Console.WriteLine($"No users have been deleted");

            }
            context.SaveChanges();
        }
    }
}
