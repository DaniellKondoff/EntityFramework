using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballDB.Models
{
    public class BetGames
    {
        [Key]
        [Column(Order = 1)]
        public int GameId { get; set; }

        public virtual Game Game { get; set; }

        [Key]
        [Column(Order = 2)]
        public int BetId { get; set; }
        public virtual Bet Bet { get; set; }

        public int ResultPredictionId { get; set; }
        public virtual ResultPrediction ResultPrediction { get; set; }
    }
}
