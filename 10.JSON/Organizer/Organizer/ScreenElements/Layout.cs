using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organizer.ScreenElements
{
    public class Layout : ScreenElement
    {
        private string[] layout;
        public Layout(int x, int y) : base(x, y)
        {

        }

        public void SetLayout(string[] layout)
        {
            this.layout = layout;
        }
        public override void Print()
        {
            for (int row = 0; row < this.layout.Length; row++)
            {
                Console.SetCursorPosition(this.x, this.y + row);
                Console.Write(this.layout[row]);
            }
        }
    }
}
