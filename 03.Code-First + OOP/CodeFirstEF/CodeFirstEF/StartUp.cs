using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstEF
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var context = new SoftUniContext();
            //context.Employees.Select(e => new {
            //    e.FirstName,
            //    e.LastName,
            //    TownName=e.Address.Town.Name
            //}).ToList().ForEach(e => Console.WriteLine(e.FirstName + " "+ e.LastName +" " + e.TownName));

            var employees = context.Employees.Join(
                context.Departments,
                (e=>e.DepartmentID),
                (d=>d.DepartmentID),
                (e,d)=>new
                {
                    Name=e.FirstName,
                    JobTitle=e.JobTitle,
                    Department=d.Name
                });

            var employyees = context.Employees.GroupBy(e => e.DepartmentID).Select(e=> new
            {
                DepartmentID= e.Key,
                AverageSelary=e.Average(d=>d.Salary)
            }).ToList();

            var avgSalByDep = context.Employees
                .GroupBy(e => e.DepartmentID)
                .Select(e => new AverageSalariesByDepartment
            {
                DepartmentID = e.Key,
                AverageSelary = e.Average(d => d.Salary)
            });

            foreach (var item in avgSalByDep)
            {
                PrintSalary(item);
            }
        }
        public static void PrintSalary(AverageSalariesByDepartment department)
        {
            Console.WriteLine($"{department.DepartmentID,4}| {department.AverageSelary}");
        }
    }



    public class AverageSalariesByDepartment
    {
        public int DepartmentID { get; set; }

        public decimal AverageSelary { get; set; }
    }
}
