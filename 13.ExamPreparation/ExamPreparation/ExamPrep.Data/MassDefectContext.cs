namespace ExamPrep.Data
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class MassDefectContext : DbContext
    {

        public MassDefectContext()
            : base("name=MassDefectContext")
        {
            //Database.SetInitializer(new DropCreateDatabaseAlways<MassDefectContext>());
        }

        public virtual DbSet<SolarSystem> SolarSystems { get; set; }
        public virtual DbSet<Star> Stars { get; set; }
        public virtual DbSet<Planet> Planets { get; set; }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<Anomoly> Anomalies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Anomoly>().HasRequired(a => a.OriginPlanet).WithMany(p => p.OriginAnomalies).HasForeignKey(a => a.OriginPlanetId).WillCascadeOnDelete(false);
            modelBuilder.Entity<Anomoly>().HasRequired(a => a.TeleportPlanet).WithMany(p => p.TargetingAnomalies).HasForeignKey(a => a.TeleportPlanetId).WillCascadeOnDelete(false);
            modelBuilder.Entity<Planet>().HasRequired(p => p.Sun).WithMany(s => s.Planet).HasForeignKey(p => p.SunId).WillCascadeOnDelete(false);
            modelBuilder.Entity<Person>()
                .HasMany(p => p.Anomalies)
                .WithMany(a => a.Victims)
                .Map(pa => {
                    pa.MapLeftKey("PersonId");
                    pa.MapRightKey("AnomalyId");
                    pa.ToTable("AnomalyVictims");
                    });
            base.OnModelCreating(modelBuilder);
        }
    }


}