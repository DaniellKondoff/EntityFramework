using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballDB.Models
{
   public class Continent
    {
        public Continent()
        {
            this.Countries = new HashSet<Country>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Country> Countries { get; set; }
    }
}
