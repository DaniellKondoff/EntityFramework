using HomeWork.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.Tasks
{
    class CallStorePROC
    {
        public static void CallProc(SoftUniContext context)
        {
            string[] nameInput = Console.ReadLine().Split(' ').ToArray();

            var projects = context.Database.SqlQuery<ProjectViewModel>("Exec usp_AllProjects {0},{1}", nameInput[0], nameInput[1]);

            foreach (ProjectViewModel project in projects)
            {
                Console.WriteLine($"{project.Name} - {project.Description}, {project.StartDate}");
            }
        }
    }
}
