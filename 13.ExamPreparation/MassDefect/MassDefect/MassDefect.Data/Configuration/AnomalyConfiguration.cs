using MassDefect.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassDefect.Data.Configuration
{
    public class AnomalyConfiguration : EntityTypeConfiguration<Anomaly>
    {
        public AnomalyConfiguration()
        {
            this.HasRequired(a => a.OriginPlanet).WithMany(p => p.OriginAnomalies).HasForeignKey(a => a.OriginPlanetId).WillCascadeOnDelete(false);
            this.HasRequired(a => a.TeleportPlanet).WithMany(p => p.TeleportAnomalies).HasForeignKey(a => a.TeleportPlanetId).WillCascadeOnDelete(false);
        }
    }
}
