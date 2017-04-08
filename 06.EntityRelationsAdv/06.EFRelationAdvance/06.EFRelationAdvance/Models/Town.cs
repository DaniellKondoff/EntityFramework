using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFRelationAdvance.Models
{
    public class Town
    {
        public Town()
        {
            this.Natives = new HashSet<Person>();
            this.Residence = new HashSet<Person>();

        }
        public int Id { get; set; }

        public int Name { get; set; }

        public virtual ICollection<Person> Natives { get; set; }

        public virtual ICollection<Person> Residence { get; set; }
    }
}
