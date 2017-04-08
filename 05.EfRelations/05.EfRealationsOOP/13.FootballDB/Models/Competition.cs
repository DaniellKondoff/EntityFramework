using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballDB.Models
{
    public class Competition
    {
        public Competition()
        {
            this.Games = new HashSet<Game>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        [ForeignKey("CompetitionType")]
        public int CompetitionTypeId { get; set; }
        public virtual CompetitionType CompetitionType { get; set; }

        public virtual ICollection<Game> Games { get; set; }
    }
}
