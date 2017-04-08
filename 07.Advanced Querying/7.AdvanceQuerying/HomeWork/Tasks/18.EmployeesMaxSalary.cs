using HomeWork.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.Tasks
{
    class EmpMaxSalary
    {
        public static void GetMaxSalary(SoftUniContext ctx)
        {
            var departs = ctx.Employees
                .GroupBy(e => e.Department)
                .Select(e => new
                {
                    DeparmentName=e.Key,
                    MaxSalary=e.Max(d=>d.Salary)
                })
                .Where(e=>e.MaxSalary<=30000 || e.MaxSalary>= 70000);

            foreach (var depart in departs)
            {
                Console.WriteLine($"{depart.DeparmentName.Name} - {depart.MaxSalary:f2}");
            }

        }
    }
}
