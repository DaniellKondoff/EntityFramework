using ProductsShop.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsShop.ModelConfiguration
{
    class ProductConfiguration : EntityTypeConfiguration<Product>
    {
        public ProductConfiguration()
        {
            this.HasMany(s => s.Categories)
                .WithMany(c => c.Products)
                .Map(sc =>
                {
                    sc.ToTable("CategoryProducts");
                    sc.MapLeftKey("Product_Id");
                    sc.MapRightKey("Category_Id");
                });
        }
    }
}
