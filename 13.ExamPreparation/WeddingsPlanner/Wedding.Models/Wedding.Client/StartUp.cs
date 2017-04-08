using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wedding.Data;

namespace Wedding.Client
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Utility.InitDb();
        }
    }
}
