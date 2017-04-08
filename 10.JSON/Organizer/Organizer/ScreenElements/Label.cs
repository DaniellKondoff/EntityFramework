using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organizer.ScreenElements
{
    class Label : ScreenElement
    {
        private string content;

        public Label(int x, int y,string content) : base(x, y)
        {
            this.content = content;
        }

        public override void Print()
        {
            Console.SetCursorPosition(this.x, this.y);
            Console.Write(this.content);
        }
    }
}
