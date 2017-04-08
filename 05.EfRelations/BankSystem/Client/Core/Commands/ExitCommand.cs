using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Core.Commands
{
    public class ExitCommand
    {
        public string Execute()
        {
            Console.WriteLine("bye Bye");
            Environment.Exit(0);
            return null;
        }
    }
}
