using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.HospitalDB.Models
{
    public partial class Patient
    {
        private string email;

        public Patient()
        {
            this.Visitations = new HashSet<Visitation>();
            this.Medicaments = new HashSet<Medicament>();
            this.Diagnoses = new HashSet<Diagnose>();
        }

        [Key]
        public int Id { get; set; }

        [MinLength(2), MaxLength(50), Required]
        public string FirstName { get; set; }

        [MinLength(2), MaxLength(50), Required]
        public string LastName { get; set; }

        [Required]
        public string Addres { get; set; }
        [Required]
        public string Email
        {
            get
            {
                return this.email;
            }
            set
            {
                if (!EmailIsValid(value))
                {
                    throw new ArgumentException("Error! Email is not in valid format");
                }
                this.email = value;
            }
        }
        public DateTime BirthDate { get; set; }
        public byte[] ProfilePicture { get; set; }
        public bool IsInsurance { get; set; }
        public virtual ICollection<Visitation> Visitations { get; set; }
        public virtual ICollection<Medicament> Medicaments { get; set; }
        public virtual ICollection<Diagnose> Diagnoses { get; set; }

    }
}
