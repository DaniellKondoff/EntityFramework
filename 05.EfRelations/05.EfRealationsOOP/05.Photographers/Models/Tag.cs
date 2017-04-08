using Photographers.Attribute;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photographers.Models
{
    public class Tag 
    {
        public Tag()
        {
            this.Albums = new HashSet<Album>();
        }
        public int Id { get; set; }

        [Tag]
        [CustomMinLenght(MinLenghtValue =5)]
        public string Label { get; set; }

        public virtual ICollection<Album> Albums { get; set; }
    }
}
