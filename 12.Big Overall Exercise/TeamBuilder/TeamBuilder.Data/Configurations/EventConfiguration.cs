using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamBuilder.Models;

namespace TeamBuilder.Data.Configurations
{
    public class EventConfiguration : EntityTypeConfiguration<Event>
    {
        public EventConfiguration()
        {
            this.HasKey(e => e.Id);

            this.Property(e => e.Name).IsRequired().HasMaxLength(25);
            this.Property(e => e.Descriprion).HasMaxLength(250);

            this.HasRequired(e => e.Creator).WithMany(c => c.CreatedEvents);

            this.HasMany(e => e.ParticipatingTeams).WithMany(t => t.Events).Map(et =>
            {
                et.MapLeftKey("EventId");
                et.MapRightKey("TeamId");
                et.ToTable("EventTeams");
            });
        }

    }
}
