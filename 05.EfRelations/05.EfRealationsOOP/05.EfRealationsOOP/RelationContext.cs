namespace RelationsDemo
{

    using RelationsDemo.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Runtime.Remoting.Contexts;

    public class RelationContext : DbContext
    {

        public RelationContext()
            : base("name=RelationContext")
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<RelationContext>());
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<RelationContext, Configuration>());
        }

        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }

        public virtual DbSet<Town> Towns { get; set; }
        public virtual DbSet<Person> People { get; set; }

        public virtual DbSet<Employee> Employees { get; set; }

        public virtual DbSet<Project> Proejcts { get; set; }

        public virtual DbSet<ProjectEmployees> ProjectEmployees { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}