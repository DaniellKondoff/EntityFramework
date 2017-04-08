namespace SimpleMapping.Data
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class EmpCtx : DbContext
    {
    
        public EmpCtx()
            : base("name=EmpCtx")
        {

        }

        public virtual DbSet<Employee> Employyees { get; set; }

    }


}