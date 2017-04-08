using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wedding.Models.Enums;

namespace Wedding.Models
{
    public class Person
    {
        public Person()
        {
            this.Bridegrooms = new HashSet<Weding>();
            this.Brides = new HashSet<Weding>();
            this.Invitations = new HashSet<Invitation>();
        }
        public int Id { get; set; }

        [Required]
        [StringLength(60,MinimumLength =1)]
        public string FirstName { get; set; }

        [Required, StringLength(1, MinimumLength = 1)]
        public string MiddleName { get; set; }

        [Required]
        [MinLength(2)]
        public string LastName { get; set; }

        [NotMapped]
        public string FullName
        {
            get
            {
                return $"{this.FirstName} {this.MiddleName} {this.LastName}";
            }
        }

        [Required]
        public Gender Gender { get; set; }

        public DateTime? Birthdate { get; set; }

        [NotMapped]
        public int? Age
        {
            get
            {
                if (Birthdate==null)
                {
                    return null;
                }
                var now = DateTime.Now;
                int age = now.Year - this.Birthdate.Value.Year;

                if (now.Month < ((DateTime)Birthdate).Month ||
                    (now.Month == ((DateTime)Birthdate).Month && now.Day < ((DateTime)Birthdate).Day))
                {
                    age--;
                }
                return age;
            }
        }

        public string Phone { get; set; }

        [RegularExpression(@"[a-zA-Z0-9]+@[a-z]{1,}.[a-z]{1,}")]
        public string Email { get; set; }

        public virtual ICollection<Weding> Brides { get; set; }

        public virtual ICollection<Weding> Bridegrooms { get; set; }

        public virtual ICollection<Invitation> Invitations { get; set; }
    }
}
