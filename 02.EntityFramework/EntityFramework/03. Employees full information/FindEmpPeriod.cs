using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Employees_full_information
{
    class FindEmpPeriod
    {
        public static void EmployeesInPeriod(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(e => e.Projects.Count(p => p.StartDate.Year >= 2001 && p.StartDate.Year <= 2003) > 0)
                .Take(30);

            foreach (var emp in employees)
            {
                Console.WriteLine($"{emp.FirstName} {emp.LastName} {emp.Manager.FirstName}");
                foreach (var project in emp.Projects)
                {
                    Console.WriteLine($"--{project.Name} {project.StartDate} {project.EndDate}");
                }
            }
            
        }
    }
}
