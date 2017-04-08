using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFRelationAdvance
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new ChirperContext();
            context.Database.Initialize(true);

           
        }
    }
}
