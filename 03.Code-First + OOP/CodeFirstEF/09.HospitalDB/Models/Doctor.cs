using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.HospitalDB.Models
{
   public class Doctor
    {
        public Doctor()
        {
            this.Visitations = new HashSet<Visitation>();
        }
        [Key]
        public int DoctorID { get; set; }

        [MinLength(2), MaxLength(50), Required]
        public string Name { get; set; }

        [Required]
        public string Speciality { get; set; }

        public virtual ICollection<Visitation> Visitations { get; set; }
    }
}
