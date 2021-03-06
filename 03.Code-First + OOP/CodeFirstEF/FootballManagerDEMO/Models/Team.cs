﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManagerDEMO.Models
{
    public class Team
    {
        public Team()
        {
            this.Players = new HashSet<Player>();
            this.Leagues = new HashSet<League>();
        }
        public int TeamId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Player> Players { get; set; }

        public virtual ICollection<League> Leagues { get; set; }
    }
}
