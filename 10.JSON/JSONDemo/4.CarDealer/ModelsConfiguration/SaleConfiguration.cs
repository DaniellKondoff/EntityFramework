using CarDealer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.ModelsConfiguration
{
    class SaleConfiguration : EntityTypeConfiguration<Sale>
    {
        public SaleConfiguration()
        {
            this.HasRequired(s => s.Car).WithRequiredDependent();

            this.HasRequired(s => s.Customer).WithMany(c => c.Sales).HasForeignKey(s => s.CustomerId);
        }
       
    }
}
