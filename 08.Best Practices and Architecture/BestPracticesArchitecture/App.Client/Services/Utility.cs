using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Client.Services
{
    class Utility
    {
        public static void SomeMethod()
        {
            Console.WriteLine(Authenticator.Instance.Current);
        }
    }
}
