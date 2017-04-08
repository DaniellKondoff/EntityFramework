namespace MassDefect.Data
{
    using Configuration;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class MassDefectContext : DbContext
    {

        public MassDefectContext()
            : base("name=MassDefectContext.cs")
        {
            //Database.SetInitializer(new DropCreateDatabaseAlways<MassDefectContext>());
        }

        public virtual DbSet<SolarSystem> SolarSystems { get; set; }

        public virtual DbSet<Star> Stars { get; set; }

        public virtual DbSet<Planet> Planets { get; set; }

        public virtual DbSet<Anomaly> Anomalies { get; set; }

        public virtual DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new PlanetConfiguration());
            modelBuilder.Configurations.Add(new AnomalyConfiguration());
            modelBuilder.Configurations.Add(new PersonConfiguration());
            base.OnModelCreating(modelBuilder); 
        }
    }


}