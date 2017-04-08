using Client.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Aplication
    {
        static void Main(string[] args)
        {
            CommandDispatcher commandDisptacher = new CommandDispatcher();
            Engine engine = new Engine(commandDisptacher);
            engine.Run();
        }
    }
}
