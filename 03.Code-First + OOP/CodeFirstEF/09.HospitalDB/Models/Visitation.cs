using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.HospitalDB.Models
{
   public class Visitation
    {

        [Key]
        public int VisitationId { get; set; }

        public DateTime VisitationDate { get; set; }
 

        [MinLength(2), MaxLength(1000), Required]
        public string Comments { get; set; }

        [Required]
        public  Patient Patient { get; set; }

        [Required]
        public  Doctor Doctor { get; set; }
    }
}
