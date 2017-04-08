using _1_2.LocalStoreAndImprovment.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_2.LocalStoreAndImprovment
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var context = new StoreContext();
            context.Database.Initialize(true);

            
        }
    }
}
