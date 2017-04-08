using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wedding.Models.Enums;

namespace Wedding.Data.DTOs
{
    public class GuestDto
    {
        public string Name { get; set; }

        public bool RSVP { get; set; }

        public Family Family { get; set; }
    }
}
