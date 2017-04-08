using MassDefect.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassDefect.Data.Configuration
{
    public class PlanetConfiguration : EntityTypeConfiguration<Planet>
    {
        public PlanetConfiguration()
        {
            this.HasRequired(p => p.Sun).WithMany(s => s.Planets).HasForeignKey(p => p.SunId).WillCascadeOnDelete(false);
            this.HasRequired(p => p.SolarSystem).WithMany(s => s.Planets).HasForeignKey(p => p.SolarSystemId).WillCascadeOnDelete(false);
        }
    }
}
