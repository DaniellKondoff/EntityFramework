using EFRelationAdvance.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFRelationAdvance.ModelConfigurations
{
    public class ChirpConfiguration : EntityTypeConfiguration<Chirp>
    {
        public ChirpConfiguration()
        {
            this.Property(c => c.Id).HasColumnName("Key");
            this.Property(c => c.Content)
                .HasMaxLength(130)
                .IsRequired();
        }
    }
}
