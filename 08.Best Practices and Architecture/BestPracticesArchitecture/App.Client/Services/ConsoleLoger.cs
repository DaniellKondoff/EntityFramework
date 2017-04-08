using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Client.Services
{
    class ConsoleLoger : Logger
    {
        public override void Log(string line)
        {
            Console.WriteLine(line);
        }
    }
}
