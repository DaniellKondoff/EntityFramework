using ExamPrep.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPrep.Client
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Utility.InitDB();
        }
    }
}
