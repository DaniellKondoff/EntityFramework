using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Employees_full_information
{
    class NativSQL
    {
        public static void GetNativeSql(SoftUniContext context)
        {
            context.Projects.Count();

            Stopwatch sw = new Stopwatch();
            sw.Start();
            LinQuery(context);
            sw.Stop();
            Console.WriteLine(sw.Elapsed);

            sw.Reset();

            sw.Start();
            NativeQuery(context);
            sw.Stop();
            Console.WriteLine(sw.Elapsed);
        }

        private static void NativeQuery(SoftUniContext context)
        {
            int result = context.Database.SqlQuery<int>("Select Count (*) FROM Projects Where Year(StartDate)>2002").First();
            Console.WriteLine(result);
        }

        private static void LinQuery(SoftUniContext context)
        {
            Console.WriteLine(context.Projects.Where(p=>p.StartDate.Year >2002).Count());
        }
    }
}
