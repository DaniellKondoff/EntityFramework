using Organizer.ScreenElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organizer.ScreenElements
{
    public class ScreenElementCollection
    {
        private List<ScreenElement> content;
        public ScreenElementCollection(List<ScreenElement> content)
        {
            this.content = content;
        }

        public void Print()
        {
            foreach (var item in content)
            {
                item.Print();
            }
        }
    }
}
