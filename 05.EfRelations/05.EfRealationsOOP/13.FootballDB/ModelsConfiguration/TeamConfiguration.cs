using FootballDB.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballDB.ModelsConfiguration
{
     public class TeamConfiguration : EntityTypeConfiguration<Team>
    {
        public TeamConfiguration()
        {
            this.Property(t => t.Initials)
                .IsFixedLength()
                .HasMaxLength(3);
        }
        
    }
}
