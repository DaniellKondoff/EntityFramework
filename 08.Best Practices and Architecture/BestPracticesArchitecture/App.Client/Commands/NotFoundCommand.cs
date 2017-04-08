using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Client.Commands
{
   public class NotFoundCommand :Command
    {
        public NotFoundCommand(MyData data) : base(data)
        {

        }

        public override Command Create(MyData data)
        {
            return new NotFoundCommand(data);
        }

        public override void Execute()
        {
            Console.WriteLine("Command not Found");
        }
    }
}
