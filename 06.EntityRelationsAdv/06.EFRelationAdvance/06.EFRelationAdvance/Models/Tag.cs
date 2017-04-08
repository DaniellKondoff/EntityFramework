using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFRelationAdvance.Models
{
    public class Tag
    {
        public Tag()
        {
            this.Chirps = new HashSet<Chirp>();
        }

        public string TagRef { get; set; }

        public virtual ICollection<Chirp> Chirps { get; set; }
    }
}
