using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wedding.Models.Enums;

namespace Wedding.Models
{
    public class Gift : Present
    {
        [Required]
        public string Name { get; set; }

        public GiftSize? Size { get; set; }
    }
}
