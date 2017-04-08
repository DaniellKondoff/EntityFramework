using Photography.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photography.Client
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            InitDB.InitializeDB();
        }
    }
}
