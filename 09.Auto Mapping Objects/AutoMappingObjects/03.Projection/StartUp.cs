using System;
using System.Collections.Generic;
using System.Linq;
using AdvanceMapping.Data;
using AutoMapper.QueryableExtensions;
using Projection.DTOs;
using Projection.Data;
using AutoMapper;
using Projection.Models;

namespace Projection
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var context = new EmpCtx();
            MapperInit.Init();

            //var emps = context.Employees
            //    .Where(e => e.BirthDay.Year < 1990)
            //    .OrderByDescending(e=>e.Salary)
            //    .ToArray();
            //List<EmployeeDto> empsDto = Mapper.Map<Employee[], List<EmployeeDto>>(emps);

            var empsDto = context.Employees
                    .Where(e => e.BirthDay.Year < 1990)
                    .OrderByDescending(e => e.Salary)
                    .ProjectTo<EmployeeDto>()
                    .ToList();

            foreach (var emp in empsDto)
            {
                if (emp.ManagerLastName==null)
                {
                    emp.ManagerLastName = "[no manager]";
                }
                Console.WriteLine($"{emp.FirstName} {emp.LastName} {emp.Salary:f2} - Manager: {emp.ManagerLastName}");
            } 
              

            
        }
    }
}
