using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManagerDEMO.Models
{
    public class League
    {
        public League()
        {
            this.Teams = new HashSet<Team>();
        }
        public int LeagueID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Team> Teams { get; set; }
    }
}
