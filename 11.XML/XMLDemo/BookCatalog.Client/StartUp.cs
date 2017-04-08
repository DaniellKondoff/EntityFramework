using BookClient.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalog.Client
{
    class StartUp
    {
        static void Main(string[] args)
        {
            InitDB.Init();
        }
    }
}
