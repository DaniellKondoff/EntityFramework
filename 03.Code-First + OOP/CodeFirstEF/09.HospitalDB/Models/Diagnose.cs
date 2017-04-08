using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.HospitalDB.Models
{
    public class Diagnose
    {
        [Key]
        public int DiagnoseId { get; set; }

        [MinLength(2), MaxLength(50), Required]
        public string Name { get; set; }

        [MinLength(2), MaxLength(1000), Required]
        public string Comments { get; set; }

        [Required]
        public Patient Patient { get; set; }
    }
}
