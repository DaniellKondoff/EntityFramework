using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Client.Commands
{
    class PrintStringCommand : Command
    {
        public PrintStringCommand(MyData data) : base(data)
        {
        }

        public override Command Create(MyData data)
        {
            return new PrintStringCommand(data);
        }

        public override void Execute()
        {
            Console.WriteLine(this.data.MyString);
        }
    }
}
