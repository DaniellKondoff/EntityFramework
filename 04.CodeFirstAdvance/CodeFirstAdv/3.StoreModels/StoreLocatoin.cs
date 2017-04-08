using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.StoreModels
{
    public class StoreLocatoin
    {
        public StoreLocatoin()
        {
            this.SalesInStore = new HashSet<Sale>();
        }
        public int Id { get; set; }
        public string StoreName { get; set; }

        public virtual ICollection<Sale> SalesInStore { get; set; }
    }
}
