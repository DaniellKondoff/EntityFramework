using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceQuerying.Models
{
   public class Client
    {
        public Client()
        {
            this.Orders = new HashSet<Order>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public string Adrress { get; set; }

        [ConcurrencyCheck]
        public int Age { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
