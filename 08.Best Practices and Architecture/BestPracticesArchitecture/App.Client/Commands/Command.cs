using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Client.Commands
{
    public abstract class Command
    {
        protected MyData data;
        public Command(MyData data)
        {
            this.data = data;
        }
        public abstract void Execute();

        public abstract Command Create(MyData data);
    }
}
