using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photography.Models
{
    public class Photographer
    {
        public Photographer()
        {
            this.Accessories = new HashSet<Accessory>();
            this.Lenses = new HashSet<Lens>();
            this.WorkshopParticipated = new HashSet<Workshop>();
            this.WorkshopTrained = new HashSet<Workshop>();
        }
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string LastName { get; set; }

        [RegularExpression(@"\+\d{1,3}\/\d{8,10}")]
        public string Phone { get; set; }

        public int PrimeryCameraId { get; set; }
        [Required]
        public virtual Camera PrimeryCamera { get; set; }

        public int SecondaryCameraId { get; set; }
        [Required]
        public virtual Camera SecondaryCamera { get; set; }

        public virtual ICollection<Lens> Lenses { get; set; }

        public virtual ICollection<Accessory> Accessories { get; set; }

        public virtual ICollection<Workshop> WorkshopTrained { get; set; }

        public virtual ICollection<Workshop> WorkshopParticipated { get; set; }
    }
}
