using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Employees_full_information
{
    class FindLatest10Projects
    {
        public static void GetLatest10Projects(SoftUniContext context)
        {
            var projects = context.Projects
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .OrderBy(p => p.Name);

            foreach (var project in projects)
            {
                Console.WriteLine($"{project.Name} {project.Description} {project.StartDate} {project.EndDate}");
            }
        }
    }
}
