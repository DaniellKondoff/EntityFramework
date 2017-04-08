using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagmentApp
{
    class StartUp
    {
        static void Main(string[] args)
        {
            //Windows Initialization
            Console.WindowHeight = 17;
            Console.BufferHeight = 17;
            Console.WindowWidth = 50;
            Console.BufferWidth = 50;

            //DB Init
            SoftUniEntities context = new SoftUniEntities();
            ListAll(context);
           
        }

        static void ListAll(SoftUniEntities context)
        {

            int pageSize = 14;

            var projects = context.Projects.ToList();
            int page = 0;
            int maxPages = (int)Math.Ceiling(projects.Count /(double)pageSize);
            int pointer = 1;

            while (true)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;

                Console.Clear();
                Console.WriteLine($" ID | Project Name (Page {page+1} of {maxPages})");
                Console.WriteLine("----+-------------------------------");

                int current = 1;
                foreach (var project in projects.Skip(pageSize * page).Take(pageSize))
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    if (current == pointer)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    Console.WriteLine($"{project.ProjectID,4}| {project.Name}");
                    current++;
                }

                var key = Console.ReadKey();

                switch (key.Key.ToString())
                {
                    case "Enter":
                        var currentProject = projects.Skip(pageSize * page + pointer - 1).First();
                        ShowDetails(currentProject);
                        break;
                    case "UpArrow":
                        if (pointer > 1)
                        {
                            pointer--;
                        }
                        else if (page > 0)
                        {
                            page--;
                            pointer = pageSize;
                        }
                        break;
                    case "DownArrow":
                        if (pointer < pageSize)
                        {
                            pointer++;
                        } 
                        else if(page+1 <= maxPages)
                        {
                            page++;
                            pointer = 1;
                        }
                        break;
                    case "Escape":
                        return;
                }
                
            }

        }

        static void ShowDetails(Project project)
        {

            //-----------------------------------------------
            Console.Clear();
            Console.WriteLine($"ID: {project.ProjectID,-4}|Project Name: {project.Name}");
            Utility.PrintHLines();
            Console.WriteLine($"Description: {project.Description}");
            Utility.PrintHLines();
            Console.WriteLine($"{project.StartDate,-24}| {project.EndDate}");
            Utility.PrintHLines();
            Console.WriteLine($"Page)");
            Utility.PrintHLines();
            int pageSize = 16-Console.CursorTop;

            var employees = project.Employees.ToList();
            int page = 0;
            int maxPages = (int)Math.Ceiling(employees.Count / (double)pageSize);
            int pointer = 1;

            while (true)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;

                Console.Clear();
                Console.WriteLine($"ID: {project.ProjectID,-4}|Project Name: {project.Name}");
                Utility.PrintHLines();
                Console.WriteLine($"Description: {project.Description}");
                Utility.PrintHLines();
                Console.WriteLine($"{project.StartDate,-24}| {project.EndDate}");
                Utility.PrintHLines();
                Console.WriteLine($"Page {page + 1} of {maxPages})");
                Utility.PrintHLines();

                int current = 1;
                foreach (var emp in employees.Skip(pageSize * page).Take(pageSize))
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    if (current == pointer)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    Console.WriteLine(emp);
                    current++;
                }

                var key = Console.ReadKey();

                switch (key.Key.ToString())
                {
                    //case "Enter":
                    //    var currentProject = employees.Skip(pageSize * page + pointer - 1).First();
                    //    ShowDetails(currentProject);
                    //    break;
                    case "UpArrow":
                        if (pointer > 1)
                        {
                            pointer--;
                        }
                        else if (page > 0)
                        {
                            page--;
                            pointer = pageSize;
                        }
                        break;
                    case "DownArrow":
                        if (pointer < pageSize)
                        {
                            pointer++;
                        }
                        else if (page + 1 <= maxPages)
                        {
                            page++;
                            pointer = 1;
                        }
                        break;
                    case "Escape":
                        return;
                }

            }
            //----------------------------------
        }


    }
}
