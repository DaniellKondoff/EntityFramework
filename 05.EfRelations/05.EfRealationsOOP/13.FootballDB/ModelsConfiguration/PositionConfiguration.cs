using FootballDB.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballDB.ModelsConfiguration
{
   public class PositionConfiguration : EntityTypeConfiguration<Position>
    {
        public PositionConfiguration()
        {
            this.HasKey(p => p.Id);
            this.Property(p => p.Id)
                .IsFixedLength()
                .HasMaxLength(2);
                
        }
    }
}
