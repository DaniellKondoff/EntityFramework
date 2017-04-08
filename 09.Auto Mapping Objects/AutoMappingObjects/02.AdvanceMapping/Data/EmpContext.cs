namespace AdvanceMapping.Data
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class EmpContext : DbContext
    {
        // Your context has been configured to use a 'EmpContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'AdvanceMapping.Data.EmpContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'EmpContext' 
        // connection string in the application configuration file.
        public EmpContext()
            : base("name=EmpContext")
        {
            
        }

        public virtual DbSet<Employee> Employees { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}