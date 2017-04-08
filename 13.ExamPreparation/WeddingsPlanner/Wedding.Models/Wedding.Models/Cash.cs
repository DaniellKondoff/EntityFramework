using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wedding.Models
{
    public class Cash : Present
    {
        [Required]
        public decimal  Amount { get; set; }
    }
}
