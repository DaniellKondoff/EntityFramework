using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organizer.ScreenElements.Composite
{
    public class TextBox : ScreenElement
    {
        private Layout layout;
        private Label label;

        public TextBox(int x, int y,int width,int height,string content) : base(x, y)
        {
            //TODO 1:28h
        }

        public override void Print()
        {
            throw new NotImplementedException();
        }
    }
}
