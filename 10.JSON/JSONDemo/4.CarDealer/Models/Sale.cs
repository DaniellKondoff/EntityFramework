﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.Models
{
    public class Sale
    {

        public int Id { get; set; }

        public int CarId { get; set; }
        public virtual Car Car { get; set; }

        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        public decimal Discaunt { get; set; }
    }
}
