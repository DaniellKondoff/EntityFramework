using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceQuerying.Models
{
    public class Order
    {
        public Order()
        {
            this.Products = new HashSet<Product>();
        }
        public int Id { get; set; }

        public int ClientId { get; set; }
        public virtual Client Client { get; set; }

        public virtual ICollection<Product> Products { get; set; } 
    }
}
