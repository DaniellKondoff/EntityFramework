using FootballDB.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballDB.ModelsConfiguration
{
    public class TownConfiguration : EntityTypeConfiguration<Town>
    {
        public TownConfiguration()
        {
            this.HasRequired(t => t.Country)
                .WithMany(c => c.Towns);
               
        }
    }
}
