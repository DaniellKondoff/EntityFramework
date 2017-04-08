using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballDB.Models
{
    public enum RoundName
    {
        Groups,
        League,
        RoundOf16,
        QuaterFinal,
        SemiFInal

    }
    public class Round
    {
        public Round()
        {
            this.Games = new HashSet<Game>();
        }
        public int Id { get; set; }

        public RoundName Name { get; set; }

        public virtual ICollection<Game> Games { get; set; }
    }
}
