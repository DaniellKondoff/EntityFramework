using FootballDB.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballDB.ModelsConfiguration
{
    class BetGamesConfiguration : EntityTypeConfiguration<BetGames>
    {
        public BetGamesConfiguration()
        {
            this.HasRequired(b => b.ResultPrediction)
                .WithMany(r => r.BetGames)
                .HasForeignKey(b => b.ResultPredictionId);
        }
    }
}
