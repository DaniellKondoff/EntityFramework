namespace BusTicketsystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class Town
    {
        public Town()
        {
            this.BusStations = new HashSet<BusStation>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }

        public virtual ICollection<BusStation> BusStations { get; set; }
    }
}