using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Employees_full_information
{
    class IncreaseSalaries
    {
        public static void GetIncreaseSalaries(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(e => e.Department.Name == "Engineering" ||
                e.Department.Name == "Tool Design" ||
                e.Department.Name == "Marketing" ||
                e.Department.Name == "Information Services");

            foreach (Employee emp in employees)
            {
                emp.Salary= emp.Salary * 1.12m;
                Console.WriteLine($"{emp.FirstName} {emp.LastName} (${emp.Salary})");
            }
            //context.SaveChanges();

        }
    }
}
