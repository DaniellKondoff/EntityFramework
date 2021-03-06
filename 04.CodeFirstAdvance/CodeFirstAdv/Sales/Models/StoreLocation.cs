﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Models
{
   public class StoreLocation
    {
        public StoreLocation()
        {
            this.SalesInStore = new HashSet<Sale>();
        }
        public int Id { get; set; }
        public string StoreName { get; set; }

        public virtual ICollection<Sale> SalesInStore { get; set; }
    }
}
