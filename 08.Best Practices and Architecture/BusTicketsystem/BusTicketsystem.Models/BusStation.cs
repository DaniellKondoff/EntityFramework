using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicketsystem.Models
{
    public class BusStation
    {
        public BusStation()
        {
            this.Reviews = new HashSet<Review>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public int TownId { get; set; }
        public virtual Town Town { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
    }
}
