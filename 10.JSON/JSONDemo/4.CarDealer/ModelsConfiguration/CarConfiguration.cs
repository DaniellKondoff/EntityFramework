using CarDealer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.ModelsConfiguration
{
    class CarConfiguration : EntityTypeConfiguration<Car>
    {
        public CarConfiguration()
        {
            this.HasKey(c => c.Id);

            this.HasMany(c => c.Parts)
                .WithMany(p => p.Cars)
                .Map(cp =>
                {
                    cp.ToTable("PartCars");
                    cp.MapLeftKey("Car_Id");
                    cp.MapRightKey("Part_Id");
                });
        }
    }
}
