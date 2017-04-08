using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballDB.Models
{
   public class PlayerStatistic
    {
        [Key]
        [Column(Order=1)]
        public int GameId { get; set; }
        public virtual Game Game { get; set; }

        [Key]
        [Column(Order = 2)]
        public int PlayerId { get; set; }
        public virtual Player Player { get; set; }

        public int ScoredGoals { get; set; }

        public int  PlayerAssists { get; set; }

        public int PlayedMinutes { get; set; }
    }
}
