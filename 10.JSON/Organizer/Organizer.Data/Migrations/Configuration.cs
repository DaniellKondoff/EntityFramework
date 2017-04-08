namespace Organizer.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models.Contacts;
    internal sealed class Configuration : DbMigrationsConfiguration<Organizer.Data.OrganizerContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Organizer.Data.OrganizerContext";
        }

        protected override void Seed(Organizer.Data.OrganizerContext context)
        {
            var person1 = new Person
            {
                FirstName = "Ivan",
                LastName = "Ivanov"
            };
            var person2= new Person
            {
                FirstName = "Peter",
                LastName = "Petrov",
                Alias="Pesho"
            };

            context.People.AddOrUpdate(p => new
            {
                p.FirstName,
                p.LastName
            },person1,person2);
            context.SaveChanges();
        }
    }
}
