using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentSystem;

namespace StudentSystem.Models
{
    public class Resource
    {
        public Resource()
        {
            this.Licenses = new HashSet<License>();
        }

        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public RecourceType TypeOfResources { get; set; }

        [Required]
        public string URL { get; set; }
        public virtual Course Course { get; set; }

        public virtual ICollection<License> Licenses { get; set; }
    }
}
