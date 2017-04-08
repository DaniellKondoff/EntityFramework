﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.StoreModels
{
    public class Product
    {
        public Product()
        {
            this.SalesOfProduct = new HashSet<Sale>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public double Quantity { get; set; }
        public decimal Price { get; set; }
        public string Descirption { get; set; }
        public virtual ICollection<Sale> SalesOfProduct { get; set; }
    }
}
