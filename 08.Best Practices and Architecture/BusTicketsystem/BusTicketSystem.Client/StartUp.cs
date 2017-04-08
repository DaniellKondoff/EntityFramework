using BusTicketSystem.Client.Core;
using BusTicketSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicketSystem.Client
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var context = new BusContext();
            context.Database.Initialize(true);

            CommandDispatcher commandDispatcher = new CommandDispatcher();

        }
    }
}
