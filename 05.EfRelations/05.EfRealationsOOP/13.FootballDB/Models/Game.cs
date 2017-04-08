using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballDB.Models
{
   public class Game
    {
        public Game()
        {
            this.PlayerStatistics = new HashSet<PlayerStatistic>();
            this.BetGames = new HashSet<BetGames>();
        }

        public int Id { get; set; }

        public int? HomeTeamId { get; set; }
        public virtual Team HomeTeam { get; set; }

        public int? AwayTeamId { get; set; }
        public virtual Team AwayTeam { get; set; }

        public int HomeGoals { get; set; }

        public int AwayGoals { get; set; }

        public DateTime GameDateTime { get; set; }

        public decimal HomeTeamWinRate { get; set; }

        public decimal AwayTeamWinRate { get; set; }

        public decimal DrawGameRate { get; set; }

        public int RoundId { get; set; }
        public virtual Round Round { get; set; }

        public int CompetitionId { get; set; }
        public virtual Competition Competition { get; set; }

        public virtual ICollection<PlayerStatistic> PlayerStatistics { get; set; }

        public virtual ICollection<BetGames> BetGames { get; set; }

    }
}
