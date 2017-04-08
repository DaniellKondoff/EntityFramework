using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicketsystem.Models
{
    public class BusCompany
    {
        public BusCompany()
        {
            this.Trips = new HashSet<Trip>();
            this.Reviews = new HashSet<Review>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public string Nationality { get; set; }

        public decimal Rating { get; set; }

        public virtual ICollection<Trip> Trips { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
    }
}
