using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballDB.Models
{
    public enum Prediction
    {
        HomeTeamWin,
        DrawGame,
        AwayTeamWin
        
    }
    public class ResultPrediction
    {
        public ResultPrediction()
        {
            this.BetGames = new HashSet<BetGames>();
        }
        public int Id { get; set; }

        public Prediction Prediction { get; set; }

        public virtual ICollection<BetGames> BetGames { get; set; }
    }
}
