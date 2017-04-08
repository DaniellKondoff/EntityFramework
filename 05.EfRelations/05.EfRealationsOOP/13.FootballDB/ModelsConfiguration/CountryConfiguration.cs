using FootballDB.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballDB.ModelsConfiguration
{
    class CountryConfiguration : EntityTypeConfiguration<Country>
    {
        public CountryConfiguration()
        {
            this.HasKey(c => c.Id);
            this.Property(c => c.Id)
                .IsFixedLength()
                .HasMaxLength(3);
        }
    }
}
