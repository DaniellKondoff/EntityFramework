using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photography.Export
{
    class StartUp
    {
        static void Main(string[] args)
        {
            //JsonExport.GetOrderedPhotographers();
            //JsonExport.GetLandscapePhotographers();
            //XmlExport.GetPhWithSameCamera();
            XmlExport.GetWorkshopsByLocation();
        }
    }
}
