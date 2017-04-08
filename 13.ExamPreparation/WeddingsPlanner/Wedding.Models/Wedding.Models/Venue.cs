using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wedding.Models
{
    public class Venue
    {
        public Venue()
        {
            this.Weddings = new HashSet<Weding>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public string Town { get; set; }

        public virtual ICollection<Weding> Weddings { get; set; }
    }
}
