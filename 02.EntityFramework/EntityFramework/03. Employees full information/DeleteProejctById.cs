using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Employees_full_information
{
    class DeleteProejctById
    {
        public static void GetDeletePrejctById(SoftUniContext context)
        {
            var project = context.Projects.Find(2);
            //.Where(p => p.ProjectID == 2);

            foreach (var emp in project.Employees)
            {
                emp.Projects.Remove(project);
            }

            context.Projects.Remove(project);
            context.SaveChanges();

            var newPorjects = context.Projects.Take(10).Select(p=>p.Name);

            foreach (var p in newPorjects)
            {
                Console.WriteLine(p);
            }
        }
    }
}
