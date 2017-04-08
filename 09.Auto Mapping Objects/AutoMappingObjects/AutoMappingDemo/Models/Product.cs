namespace AutoMappingDemo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Product
    {
       
        public Product()
        {
            Orders = new HashSet<Order>();
            ProductStocks = new HashSet<ProductStock>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Cost { get; set; }

        public virtual ICollection<ProductStock> ProductStocks { get; set; }      
        public virtual ICollection<Order> Orders { get; set; }
    }
}
