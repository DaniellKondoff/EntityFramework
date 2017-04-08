using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPrep.Models
{
    public class Planet
    {
        public Planet()
        {
            this.Persons = new HashSet<Person>();
            this.OriginAnomalies = new HashSet<Anomoly>();
            this.TargetingAnomalies = new HashSet<Anomoly>();
        }
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int SunId { get; set; }
        public virtual Star Sun { get; set; }

        public int SolarSystemId { get; set; }
        public virtual SolarSystem SolarSystem { get; set; }

        public virtual ICollection<Person> Persons { get; set; }

        public virtual ICollection<Anomoly> OriginAnomalies { get; set; }

        public virtual ICollection<Anomoly> TargetingAnomalies { get; set; }
    }
}
