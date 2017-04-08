using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Organizer.Data;
using Organizer.ScreenElements;
using Organizer.Utility;

namespace Organizer
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var context = new OrganizerContext();
            //context.Database.Initialize(true);
            Console.CursorVisible = false;

            var label = new Label(5, 5, "Hello Labeel");
          

            var para = new List<string>();
            para.Add("Hello list");
            para.Add("Bye Bye");
            var element = new Parapraph(5, 9, para);

            var layout = new Layout(4, 4);

            layout.SetLayout(Composer.Compose(Composer.GetBox(14, 3)));


            List<ScreenElement> list = new List<ScreenElement>();
            list.Add(layout);
            list.Add(label);
            list.Add(element);
            var screen = new ScreenElementCollection(list);
            screen.Print();
            Console.ReadKey(true);
        }
    }
}
