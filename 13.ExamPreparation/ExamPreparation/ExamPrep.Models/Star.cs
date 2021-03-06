﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPrep.Models
{
    public class Star
    {
        public Star()
        {
            this.Planet = new HashSet<Planet>();
        }
        public int Id { get; set; }

        [Required]
        public string  Name { get; set; }

        public int SolarSystemId { get; set; }
        public virtual SolarSystem SolarSystem { get; set; }

        public virtual ICollection<Planet> Planet { get; set; }
    }
}
