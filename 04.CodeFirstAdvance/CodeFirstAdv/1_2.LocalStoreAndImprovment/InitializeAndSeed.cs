using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1_2.LocalStoreAndImprovment.Model;
using System.Data.Entity;

namespace _1_2.LocalStoreAndImprovment
{
    class InitializeAndSeed :DropCreateDatabaseIfModelChanges<StoreContext>
    {
        protected override void Seed(StoreContext context)
        {
            var product1 = new Product()
            {
                Name = "Bob",
                DistributorName = "EOOD",
                Description = "Mnogo vkusno",
                Price = 1.50m
            };
            var product2 = new Product()
            {
                Name = "Oriz",
                DistributorName = "EOOD",
                Description = "Mnogo vkusno",
                Price = 2.50m
            };
            var product3 = new Product()
            {
                Name = "Leshta",
                DistributorName = "EOOD",
                Description = "Mnogo vkusno",
                Price = 0.5m
            };
            var product4 = new Product()
            {
                Name = "Leshta",
                DistributorName = "EOOD",
                Description = "Mnogo vkusno",
                Price = 0.5m
            };

            context.Products.AddRange(new[] { product1, product2, product3,product4 });
            context.SaveChanges();
            base.Seed(context); 
        }
    }
}
