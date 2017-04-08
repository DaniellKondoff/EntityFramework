using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Employees_full_information
{
    class EmployeesId147
    {
        public static void GetEmployeeId(SoftUniContext context)
        {
            var employee = context.Employees.Where(e => e.EmployeeID.Equals(147)).First();

            Console.WriteLine($"{employee.FirstName} {employee.LastName} {employee.JobTitle}");
            var projects = employee.Projects.OrderBy(p => p.Name);
            foreach (var project in projects)
            {
                Console.WriteLine(project.Name);
            }

            
        }
    }
}
