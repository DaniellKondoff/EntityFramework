using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMappingDemo.Models
{
    public class Storage
    {
        public Storage()
        {
            ProductStocks = new HashSet<ProductStock>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public virtual ICollection<ProductStock> ProductStocks { get; set; }

    }
}
