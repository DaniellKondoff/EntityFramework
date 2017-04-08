using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wedding.Models.Enums;

namespace Wedding.Models
{
    public class Invitation
    {
        public int Id { get; set; }

        [Required]
        public virtual Weding Wedding { get; set; }

        [Required]
        public virtual Person Guest { get; set; }

        public virtual Present Present { get; set; }

        public bool IsAttending { get; set; }

        [Required]
        public Family Family { get; set; }


    }
}
