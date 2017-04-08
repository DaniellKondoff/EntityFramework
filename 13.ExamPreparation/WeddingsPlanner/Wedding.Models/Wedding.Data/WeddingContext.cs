namespace Wedding.Data
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class WeddingContext : DbContext
    {
        public WeddingContext()
            : base("name=WeddingContext")
        {
            //Database.SetInitializer(new DropCreateDatabaseAlways<WeddingContext>());
        }


        public virtual DbSet<Agency> Agency { get; set; }

        public virtual DbSet<Invitation> Invitations { get; set; }

        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Venue> Venue { get; set; }

        public virtual DbSet<Weding> Weddings { get; set; }

        public virtual DbSet<Present> Presents { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Present>()
                .HasKey(p => p.InvitationId);

            modelBuilder.Entity<Present>()
                .HasRequired(p => p.Invitation)
                .WithRequiredPrincipal(i => i.Present).WillCascadeOnDelete(false);

            modelBuilder.Entity<Weding>()
                .HasRequired(w => w.Bride)
                .WithMany(p => p.Brides)
                .HasForeignKey(w => w.BrideId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Weding>()
                .HasRequired(w => w.Bridegroom)
                .WithMany(p => p.Bridegrooms)
                .HasForeignKey(w => w.BridegroomId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Weding>()
                .HasRequired(w => w.Agency)
                .WithMany(a => a.Weddings)
                .HasForeignKey(w => w.AgencyId)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }

    }

}