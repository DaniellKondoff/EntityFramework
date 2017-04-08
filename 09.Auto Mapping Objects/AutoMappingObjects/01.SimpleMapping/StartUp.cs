using AutoMapper;
using SimpleMapping.Data;
using SimpleMapping.DTOs;
using SimpleMapping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMapping
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var context = new EmpCtx();
            //context.Database.Initialize(true);

            var employee = new Employee()
            {
                FirstName="Pesho",
                LastName="Peshev",
                BirthDay=DateTime.Now,
                Salary=1000m,
                Address="Bulgaria, Sofia"
            };
            //context.Employyees.Add(employee);
            //context.SaveChanges();
            EmployeeDto empDto;
            Mapper.Initialize(cfg => cfg.CreateMap<Employee, EmployeeDto>());

            using (context)
            {
                empDto = Mapper.Map<EmployeeDto>(employee);
            }
             
            Console.WriteLine($"{empDto.FirstName} {empDto.LastName} {empDto.Salary}");
        }
    }
}
