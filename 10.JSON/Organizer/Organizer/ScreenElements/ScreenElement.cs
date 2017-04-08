using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organizer.ScreenElements
{
    public abstract class ScreenElement
    {
        protected int x;
        protected int y;
   

        public ScreenElement(int x,int y)
        {
            this.x = x;
            this.y = y;
           
        }

        public abstract void Print();
       
    }
}
