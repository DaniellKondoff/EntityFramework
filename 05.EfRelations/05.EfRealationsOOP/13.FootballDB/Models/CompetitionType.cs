using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballDB.Models
{
    public enum Type
    {
        Local,
        National,
        International
    }
   public class CompetitionType
    {
        public CompetitionType()
        {
            this.Competitions = new HashSet<Competition>();
        }
        public int Id { get; set; }
        public Type Name { get; set; }

        public virtual ICollection<Competition> Competitions { get; set; }
    }
}
