using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Employees_full_information
{
    class DepartmentsMoreThan5Emp
    {
        public static void GetDepartmentsMoreThan5Emp(SoftUniContext context)
        {
            var departments = context.Departments
                .Where(d => d.Employees.Count > 5)
                .OrderBy(d=>d.Employees.Count)
                .ToList();

            foreach (var dep in departments)
            {
                Console.WriteLine($"{dep.Name} {dep.Manager.FirstName}");
                foreach (var emp in dep.Employees.OrderBy(e=>e.EmployeeID))
                {
                    Console.WriteLine($"{emp.FirstName} {emp.LastName} {emp.JobTitle}");
                }
            }
        }
    }
}
