using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework
{
    class EFDemo
    {
        static void Main(string[] args)
        {
            //Read
            var context = new SoftUniEntities();
            var employee = context.Employees.Find(1);
            Console.WriteLine(employee.FirstName + ' ' + employee.LastName);
            var employees = context.Employees
                .Where(e => e.Salary>50000)
                .Select(e=> new {
                    e.FirstName,
                    e.LastName,
                    e.Salary
                })
                .ToList();
            foreach (var emp in employees)
            {
                Console.WriteLine($"{emp.FirstName} {emp.LastName} - {emp.Salary}");
            }

            //insert
            var town = new Town();
            town.Name = "Stara Zagora";
            context.Towns.Add(town);
            context.SaveChanges();

            //Cascade Insert
            var addr = new Address();
            addr.AddressText=("Some Adress");
            addr.Town = new Town() { Name = "Velingrad" };
            context.Addresses.Add(addr);
            context.SaveChanges();

            //Update
            var empp = context.Employees.First();
            empp.FirstName = "Dani";
            employee.Department = context.Departments.First();
            context.SaveChanges();

            var departament = context.Departments.First();
            var guys = departament.Employees.ToList();

            foreach (var guy in guys)
            {
                Console.WriteLine(guy.FirstName);
            }

            //Delete


        }
    }
}
