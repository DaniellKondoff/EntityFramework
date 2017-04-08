using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Client.Commands
{
    public class PrintNumber : Command
    {
        public PrintNumber(MyData data) : base(data)
        {
        }

        public override Command Create(MyData data)
        {
            return new PrintNumber(data);
        }

        public override void Execute()
        {
            Console.WriteLine(this.data.Number);
        }
    }
}
