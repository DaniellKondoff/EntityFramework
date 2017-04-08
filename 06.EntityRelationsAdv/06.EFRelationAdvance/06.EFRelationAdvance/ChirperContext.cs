namespace EFRelationAdvance
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Models;
    using ModelConfigurations;

    public class ChirperContext : DbContext
    {

        public ChirperContext()
            : base("name=ChirperContext")
        {

        }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Chirp> Chirps { get; set; }
        public virtual DbSet<ChImg> Images { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<Town> Towns { get; set; }
        public virtual DbSet<Person> Persons { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new ChirpConfiguration());
            modelBuilder.Configurations.Add(new ChImgConfiguration());

            //modelBuilder.Entity<Chirp>().HasKey(e => e.Id);
            //modelBuilder.Entity<User>().ToTable("People");
            //modelBuilder.Entity<Chirp>().Property(c => c.Id).HasColumnName("Key");
            //modelBuilder.Entity<User>().HasKey(u => u.Key);
            //modelBuilder.Entity<Chirp>().Property(c => c.Content)
            //    .HasMaxLength(130)
            //    .IsRequired();
            //modelBuilder.Entity<User>().Property(u => u.Alias)
            //    .IsRequired()
            //    .HasMaxLength(50)
            //    .IsUnicode(false);

            //One to Zero
            //modelBuilder.Entity<ChImg>().HasRequired(c => c.Chirp).WithOptional(c => c.Image);
            //One-To-One
            //modelBuilder.Entity<ChImg>()
            //    .HasKey(c=>c.ChirpId)
            //    .HasRequired(c => c.Chirp)
            //    .WithRequiredDependent(c => c.Image);

            //One-To-Many
            modelBuilder.Entity<Comment>()
                .HasRequired(c => c.Chirp)
                .WithMany(c => c.Comments)
                .HasForeignKey(c => c.ChirpRefId);

            //Many-To-Many
            modelBuilder.Entity<Tag>().HasKey(t => t.TagRef)
                .HasMany(t=>t.Chirps)
                .WithMany(c=>c.Tags)
                .Map(tc=>
                {
                    tc.ToTable("ChirpTags");
                    tc.MapLeftKey("TagRef");
                    tc.MapRightKey("ChirpId");
                });

            //Ignore Property
            //modelBuilder.Entity<User>().Ignore(u => u.CurrentSessionId);

            modelBuilder.Entity<Person>().HasOptional(p => p.PlaceOfBirth).WithMany(t => t.Natives)
                .HasForeignKey(t => t.PlaceOfBirthId);
            modelBuilder.Entity<Person>().HasOptional(p => p.CurrentResidense).WithMany(t => t.Residence)
                .HasForeignKey(t => t.CurrentResidenseId);

            base.OnModelCreating(modelBuilder);
        }

    }


}