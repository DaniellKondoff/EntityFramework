using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicketsystem.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        public decimal Price { get; set; }

        public string Seat { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public string Trip { get; set; }

    }
}
