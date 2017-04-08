using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wedding.Models
{
    public class Agency
    {
        public Agency()
        {
            this.Weddings = new HashSet<Weding>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public int EmployeesCount { get; set; }

        public string Town { get; set; }

        public virtual ICollection<Weding> Weddings { get; set; }
    }
}
