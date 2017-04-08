using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem.Models
{
   public class License
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [ForeignKey("Resource")]
        public int ResourceId { get; set; }
        public virtual Resource Resource { get; set; }
    }
}
