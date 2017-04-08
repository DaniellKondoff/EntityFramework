namespace Projection.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Models;

    public partial class EmpCtx : DbContext
    {
        public EmpCtx()
            : base("name=EmpCtx")
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Employees)
                .WithOptional(e => e.Manager)
                .HasForeignKey(e => e.Manager_Id);
        }
    }
}
