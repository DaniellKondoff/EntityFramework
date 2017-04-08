using EFRelationAdvance.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFRelationAdvance.ModelConfigurations
{
    public class ChImgConfiguration : EntityTypeConfiguration<ChImg>
    {
        public ChImgConfiguration()
        {
            this.HasKey(c => c.ChirpId)
                .HasRequired(c => c.Chirp)
                .WithRequiredDependent(c => c.Image);
        }
    }
}
