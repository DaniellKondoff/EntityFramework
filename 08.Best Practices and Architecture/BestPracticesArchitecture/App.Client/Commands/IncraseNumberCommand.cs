using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Client.Commands
{
    public class IncraseNumberCommand : Command
    {
        public IncraseNumberCommand(MyData data) : base(data)
        {
        }

        public override Command Create(MyData data)
        {
            return new IncraseNumberCommand(data);
        }

        public override void Execute()
        {
            this.data.Number++;
        }
    }
}
