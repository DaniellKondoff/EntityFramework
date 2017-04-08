using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Client.Commands
{
    class PrintGreetingCommand : Command
    {
        public PrintGreetingCommand(MyData data) : base(data)
        {
        }

        public override Command Create(MyData data)
        {
            throw new NotImplementedException();
        }

        public override void Execute()
        {
            Console.WriteLine("Hello,Command Pattern");
        }
    }
}
