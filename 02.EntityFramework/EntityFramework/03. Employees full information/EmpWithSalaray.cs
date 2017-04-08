using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Employees_full_information
{
    public class EmpWithSalaray
    {
        public static void EmpWithSalara500(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(e => e.Salary >= 50000)
                .OrderBy(e=>e.EmployeeID)
                .Select(e => e.FirstName)
                .ToList();

            foreach (var emp in employees)
            {
                Console.WriteLine(emp);
            }
        }
    }
}
