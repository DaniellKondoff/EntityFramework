using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMappingDemo.Models
{
    public class ProductStock
    {
        
        public int Quantity { get; set; }

        [Key]
        [Column(Order = 1)]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        [Key]
        [Column(Order = 2)]
        public int StorageId { get; set; }
        public virtual Storage Storage { get; set; }
    }
}
