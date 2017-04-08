using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicketsystem.Models
{
    public class Trip
    {
        public int Id { get; set; }

        public DateTime DepartureTime { get; set; }

        public DateTime ArrivalTime { get; set; }

        public TripStatus Status { get; set; }

    
        public virtual BusStation OriginBusStation { get; set; }
      
        public virtual BusStation DestinationBusStation { get; set; }
      
        public virtual BusCompany BusCompany { get; set; }
    }

    public enum TripStatus
    {
        Departed,
        Arrived,
        Delayed,
        Cancelled
    }
}
