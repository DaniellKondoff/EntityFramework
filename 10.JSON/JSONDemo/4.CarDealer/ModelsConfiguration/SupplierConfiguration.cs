using CarDealer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.ModelsConfiguration
{
    class SupplierConfiguration : EntityTypeConfiguration<Supplier>
    {
        public SupplierConfiguration()
        {
            this.HasMany(s => s.Parts)
                .WithRequired(p => p.Supplier)
                .HasForeignKey(p => p.SupplierId);
        }
    }
}
