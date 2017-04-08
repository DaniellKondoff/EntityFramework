using MassDefect.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassDefect.Data.Configuration
{
    public class PersonConfiguration : EntityTypeConfiguration<Person>
    {
        public PersonConfiguration()
        {
            this.HasMany(p => p.Anomalies)
                .WithMany(a => a.Victims)
                .Map(av =>
                {
                    av.MapLeftKey("PersonId");
                    av.MapRightKey("AnomalyId");
                    av.ToTable("AnomalyVictims");
                });
        }
    }
}
