using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamBuilder.Models
{
    public class Team
    {
        public Team()
        {
            this.Members = new HashSet<User>();
            this.Events = new HashSet<Event>();
            this.Invitations = new HashSet<Invitation>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Acronym { get; set; }

        public int CreatorId { get; set; }
        public virtual User Creator { get; set; }
        public virtual ICollection<User> Members { get; set; }

        public virtual ICollection<Event> Events { get; set; }

        public virtual ICollection<Invitation> Invitations { get; set; }
    }
}
