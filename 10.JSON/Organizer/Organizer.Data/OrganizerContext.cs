namespace Organizer.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Models.Contacts;
    using Migrations;

    public class OrganizerContext : DbContext
    {

        public OrganizerContext()
            : base("name=OrganizerContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<OrganizerContext,Configuration>());
        }



        public virtual DbSet<Person> People { get; set; }

        public virtual DbSet<Email> Emails { get; set; }

        public virtual DbSet<Phone> Phones { get; set; }
    }


}