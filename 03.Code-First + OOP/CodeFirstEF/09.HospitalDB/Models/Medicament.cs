using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.HospitalDB.Models
{
   public class Medicament
    {
        public Medicament()
        {
            this.Patients = new HashSet<Patient>();
        }

        [Key]
        public int MedicamentId { get; set; }

        [MinLength(2), MaxLength(50), Required]
        public string Name { get; set; }

        [Required]
        public ICollection<Patient> Patients { get; set; }
    }
}
