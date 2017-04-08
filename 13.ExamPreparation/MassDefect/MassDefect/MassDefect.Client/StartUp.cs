using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MassDefect.Data.Utility;

namespace MassDefect.Client
{
    class StartUp
    {
        static void Main(string[] args)
        {
            InitializeDb.InitDB();
        }
    }
}
