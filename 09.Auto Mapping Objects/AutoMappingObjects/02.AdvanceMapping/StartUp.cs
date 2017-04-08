using AdvanceMapping.Data;
using AdvanceMapping.Dto;
using AdvanceMapping.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceMapping
{
    class StartUp
    {

        

        static void Main(string[] args)
        {
            var context = new EmpContext();
            //context.Database.Initialize(true);

            List<Employee> employeeList = new List<Employee>();

            var emp1 = new Employee()
            {
                FirstName = "Stephane",
                LastName = "Bjorn",
                Salary = 4300,
                BirthDay = new DateTime(2012, 08, 08)
            };
            var emp2 = new Employee()
            {
                FirstName = "Kirilyc",
                LastName = "Lefi",
                Salary = 4400,
                BirthDay = new DateTime(2001, 08, 08)
            };
            var empM1 = new Employee()
            {
                FirstName = "Steve",
                LastName = "Jobbsen",
                Salary = 50000,
                BirthDay = new DateTime(1990, 08, 08)
            };
            emp1.Manager = empM1;
            emp2.Manager = empM1;
            empM1.Employees.Add(emp1);
            empM1.Employees.Add(emp2);

            var empM2 = new Employee()
            {
                FirstName = "Carl",
                LastName = "Kormac",
                Salary = 50000,
                BirthDay = new DateTime(1980, 01, 01)
            };
            var emp3 = new Employee()
            {
                FirstName = "Jurgen",
                LastName = "Straus",
                Salary = 1000.45m,
                BirthDay = new DateTime(1930, 07, 07)
            };
            var emp4 = new Employee()
            {
                FirstName = "Moni",
                LastName = "Kozinac",
                Salary = 2030.99m,
                BirthDay = new DateTime(1959, 06, 13)
            };
            var emp5 = new Employee()
            {
                FirstName = "Kopp",
                LastName = "Spidok",
                Salary = 2000.21m,
                BirthDay = new DateTime(1965, 04, 08)
            };
            emp3.Manager = empM2;
            emp4.Manager = empM2;
            emp5.Manager = empM2;
            empM2.Employees.Add(emp3);
            empM2.Employees.Add(emp4);
            empM2.Employees.Add(emp5);

            employeeList.AddRange(new[] { empM1, empM2});
            //context.Employees.AddRange(employeeList);
            //context.SaveChanges();

            MapperInit.Init();
            List<ManagerDto> managerDtos = Mapper.Map<List<ManagerDto>>(employeeList);

            foreach (var manager in managerDtos)
            {
                Console.WriteLine($"{manager.FirstName} {manager.LastName} | Employees: {manager.EmployeesCount}");

                var employess = Mapper.Map<List<EmployeeDto>>(manager.EmployeesInCharge);

                foreach (var emp in employess)
                {
                    Console.WriteLine($"- {emp.FirstName} {emp.LastName} {emp.Salary}");
                }
                
            }

        }
    }
}
