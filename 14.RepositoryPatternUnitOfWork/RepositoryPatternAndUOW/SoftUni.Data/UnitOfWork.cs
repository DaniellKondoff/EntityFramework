using SoftUni.Data.Contracts;
using SoftUni.Data.Repository;
using SoftUni.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUni.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SoftUniDbContext context = new SoftUniDbContext();
        private IRepository<Employee> employees;
        private IRepository<Town> towns;

        public IRepository<Employee> Employees
        {
            get
            {
                return this.employees ?? (this.employees = new Repository<Employee>(context));
            }
        }

        public IRepository<Town> Towns
        {
            get
            {
                return this.towns ?? (this.towns = new Repository<Town>(context));
            }
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }
    }
}
