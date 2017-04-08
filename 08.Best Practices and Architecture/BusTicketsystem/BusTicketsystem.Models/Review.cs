using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicketsystem.Models
{
    public class Review
    {
        public int Id { get; set; }

        public string Content { get; set; }

        [Range(0.0,10.0)]
        public decimal Grade { get; set; }

        public int BusStationId { get; set; }
        public virtual BusStation BusStation { get; set; }

        public virtual Customer Customer { get; set; }

        public DateTime PublishingDateTime { get; set; }

        public int BusCompanyId { get; set; }
        public virtual BusCompany BusCompany { get; set; }
    }
}
