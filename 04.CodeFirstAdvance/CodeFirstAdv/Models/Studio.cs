using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
   public class Studio
    {
        public Studio()
        {
            this.Movies = new HashSet<Movie>();
        }
        public int Id { get; set; }

        public string Name { get; set; }
        public decimal Revenue { get; set; }
        public virtual ICollection<Movie> Movies { get; set; }
    }
}
