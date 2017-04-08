using Photography.Models.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photography.Models
{
    public class Camera
    {
        public Camera()
        {
            this.PrimaryCamerasPhotographers = new HashSet<Photographer>();
            this.SecondaryCamerasPhotographers = new HashSet<Photographer>();
        }
        public int Id { get; set; }

        [Required]
        public string Make { get; set; }
        [Required]
        public string Model { get; set; }

        public bool IsFullFrame { get; set; }
        [MinValue]
        public int MinIso { get; set; }

        public int? MaxIso { get; set; }

        public virtual ICollection<Photographer> PrimaryCamerasPhotographers { get; set; }

        public virtual ICollection<Photographer> SecondaryCamerasPhotographers { get; set; }
    }
}
