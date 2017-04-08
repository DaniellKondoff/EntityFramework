using HomeWork;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork
{
    class StartUp
    {
        static void Main(string[] args)
        {
            EmployeeContext context = new EmployeeContext();
            Stopwatch stopwatch = new Stopwatch();
            long timePassed = 0L;
            int testCount = 10; // Amount of tests to perform
            for (int i = 0; i < testCount; i++)
            {
                // Clear all query cache
                context.Database.ExecuteSqlCommand("CHECKPOINT; DBCC DROPCLEANBUFFERS;");
                stopwatch.Start();

                // TODO: Method to execute query
                //QueryWithEagerLoading(context);
                //QueryWithLazyLoading(context);
                //QueryWithEagerLoadingSelect(context);
                //QueryWithLazyLoadingSelect(context);
                //QueryWithEagerLoading3(context);
                QueryWithLazyLoading3(context);
                stopwatch.Stop();
                timePassed += stopwatch.ElapsedMilliseconds;
                stopwatch.Reset();
            }

            TimeSpan averageTimePassed = TimeSpan.FromMilliseconds(timePassed / (double)testCount);
            Console.WriteLine(averageTimePassed);

        }
        private static void QueryWithEagerLoading(EmployeeContext context)
        {
            List<Employee> employes = context.Employees.Include("Departments").Include("Address").Where(e => e.Salary < 3000).ToList();

            foreach (var emp in employes)
            {
                string result = $"{emp.FirstName}{emp.Department.Name}{emp.Address.AddressText}";
            }
        }
        private static void QueryWithEagerLoadingSelect(EmployeeContext context)
        {
            var employes = context.Employees
                .Include("Departments")
                .Include("Address")
                .Select(e => new
                {
                    Name = e.FirstName,
                    DepartamentName = e.Department.Name,
                    Address = e.Address.AddressText
                })
                .ToList();

            foreach (var emp in employes)
            {
                string result = $"{emp.Name}{emp.DepartamentName}{emp.Address}";
            }
        }
        private static void QueryWithLazyLoading(EmployeeContext context)
        {
            List<Employee> employes = context.Employees.Where(e => e.Salary < 3000).ToList();

            foreach (var emp in employes)
            {
                string result = $"{emp.FirstName}{emp.Department.Name}{emp.Address.AddressText}";
            }
        }
        private static void QueryWithLazyLoadingSelect(EmployeeContext context)
        {
            var employes = context.Employees
                .Select(e => new
                {
                    Name = e.FirstName,
                    Departmentname = e.Department.Name,
                    AddressText = e.Address.AddressText
                })
                .ToList();

            foreach (var emp in employes)
            {
                string result = $"{emp.Name}{emp.Departmentname}{emp.AddressText}";
            }
        }
        private static void QueryWithEagerLoading3(EmployeeContext context)
        {
            var employes = context.Employees.Include("Departments").OrderBy(e => e.Department.Name).ThenBy(e => e.FirstName).ToList();

            foreach (var emp in employes)
            {
                string result = $"{emp.FirstName}{emp.Department.Name}";
            }
        }
        private static void QueryWithLazyLoading3(EmployeeContext context)
        {
            var employees = context.Employees
                .Where(e => e.Employees1.Any(s => s.Address.Town.Name.StartsWith("B")))
                 .Distinct()
                 .ToList();

            foreach (var emp in employees)
            {
                string result = $"{emp.FirstName}{emp.Department.Name}";
            }
        }
    }


}
