using FootballDB.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballDB.ModelsConfiguration
{
    class GameConfiguration : EntityTypeConfiguration<Game>
    {
        public GameConfiguration()
        {
            this.HasOptional(g => g.HomeTeam)
                .WithMany(t => t.HomeTeams)
                .HasForeignKey(t => t.HomeTeamId);

            this.HasOptional(g => g.AwayTeam)
                .WithMany(t => t.AwayTeams)
                .HasForeignKey(t => t.AwayTeamId);

            this.HasRequired(g => g.Round)
                .WithMany(r => r.Games)
                .HasForeignKey(g => g.RoundId);

            this.HasRequired(g => g.Competition)
                .WithMany(c => c.Games)
                .HasForeignKey(g => g.CompetitionId);

        
        }

    }
}
