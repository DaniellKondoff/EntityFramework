using Photography.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photography.Data.Configuration
{
    public class PhotographerConfiguration : EntityTypeConfiguration<Photographer>
    {
        public PhotographerConfiguration()
        {
            this.HasRequired(p => p.PrimeryCamera)
                .WithMany(c => c.PrimaryCamerasPhotographers)
                .HasForeignKey(p => p.PrimeryCameraId)
                .WillCascadeOnDelete(false);

            this.HasRequired(p => p.SecondaryCamera)
                .WithMany(c => c.SecondaryCamerasPhotographers)
                .HasForeignKey(p => p.SecondaryCameraId)
                .WillCascadeOnDelete(false);

            this.HasMany(p => p.WorkshopTrained)
                .WithRequired(w => w.Trainer)
                .HasForeignKey(w => w.TrainerId)
                .WillCascadeOnDelete(false);

            this.HasMany(p => p.WorkshopParticipated)
                .WithMany(w => w.Participants)
                .Map(pw =>
                {
                    pw.MapLeftKey("PhotographerId");
                    pw.MapRightKey("WorkshopId");
                    pw.ToTable("Enrollment");
                });

        }
    }
}
