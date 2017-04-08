using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballDB.Models
{
    public enum PositionDescription
    {
        GoalKeeper,
        Defender,
        Midfielder,
        Forwarder
    }
    public class Position
    {
        public Position()
        {
            this.Players = new HashSet<Player>();
        }
        public string Id { get; set; }
        public PositionDescription PositionDesciption { get; set; }
        public virtual ICollection<Player> Players { get; set; }
    }
}
