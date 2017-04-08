using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPrep.Models
{
    public class Person
    {
        public Person()
        {
            this.Anomalies = new HashSet<Anomoly>();
        }
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int HomePlanetId { get; set; }
        public virtual Planet HomePlanet { get; set; }

        public virtual ICollection<Anomoly> Anomalies { get; set; }
    }
}
