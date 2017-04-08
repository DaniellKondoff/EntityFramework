using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballDB.Models
{
    public class Bet
    {
        public Bet()
        {
            this.BetGames = new HashSet<BetGames>();
        }
        public int Id { get; set; }
        public decimal BetMoney { get; set; }
        public DateTime DateOfBet { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

        public virtual ICollection<BetGames> BetGames { get; set; }

    }
}
