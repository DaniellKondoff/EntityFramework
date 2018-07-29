using SoftUni.Data;
using SoftUni.Data.Repository;
using SoftUni.Models;
using System;

namespace SoftUni.Client
{
    class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniDbContext db = new SoftUniDbContext();
            Repository<Employee> empRepo = new Repository<Employee>(db);
            UnitOfWork unitOfWork = new UnitOfWork();
            
            Employee emp = empRepo.GetById(1);
            var emp1 = unitOfWork.Employees.GetById(1);
            Console.WriteLine(emp.FirstName);
            Console.WriteLine(emp1.FirstName);
        }
    }
}
