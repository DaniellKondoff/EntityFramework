using FootballDB.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.FootballDB
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var contex = new FootbalContext();

            contex.Database.Initialize(true);
        }
    }
}
