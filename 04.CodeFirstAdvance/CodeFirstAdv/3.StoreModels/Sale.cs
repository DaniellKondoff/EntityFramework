using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.StoreModels
{
    public class Sale
    {
        public int Id { get; set; }
  
        public Product Product { get; set; }
        public Customer Customer { get; set; }
        public StoreLocatoin StoreLocation { get; set; }
        public DateTime Date { get; set; }

        
    }
}
