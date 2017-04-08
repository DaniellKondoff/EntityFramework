using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using _3.StoreModels;

namespace _3.StoreData
{
    class InitializeAndSeed :CreateDatabaseIfNotExists<SalesContext>
    {

        protected override void Seed(SalesContext context)
        {
            //var product1 = new Product()
            //{
            //    Name = "p1",
            //    Quantity = 1,
            //    Price = 1.5m,              
            //};
            //var product2 = new Product()
            //{
            //    Name = "p1",
            //    Quantity = 1,
            //    Price = 1.5m
            //};
            //var product3 = new Product()
            //{
            //    Name = "p1",
            //    Quantity = 1,
            //    Price = 1.5m
            //};
            //var product4 = new Product()
            //{
            //    Name = "p1",
            //    Quantity = 1,
            //    Price = 1.5m
            //};
            //var product5 = new Product()
            //{
            //    Name = "p1",
            //    Quantity = 1,
            //    Price = 1.5m
            //};
            //context.Products.AddRange(new[] {product1,product2,product3,product4,product5});
            //var customer1 = new Customer()
            //{
            //    Name = "c1",
            //    CreditCardNumber = "123",
            //    Email = "c1@as.com"
            //};
            //var customer2 = new Customer()
            //{
            //    Name = "c2",
            //    CreditCardNumber = "123",
            //    Email = "c1@as.com"
            //};
            //var customer3 = new Customer()
            //{
            //    Name = "c3",
            //    CreditCardNumber = "123",
            //    Email = "c1@as.com"
            //};
            //var customer4 = new Customer()
            //{
            //    Name = "c4",
            //    CreditCardNumber = "123",
            //    Email = "c1@as.com"
            //};
            //var customer5 = new Customer()
            //{
            //    Name = "c5",
            //    CreditCardNumber = "123",
            //    Email = "c1@as.com"
            //};
            //context.Customers.AddRange(new[] { customer1, customer2, customer3, customer4, customer5 });
            //var sLocation1 = new StoreLocatoin()
            //{
            //    StoreName="Store1"
            //};
            //var sLocation2 = new StoreLocatoin()
            //{
            //    StoreName = "Store2"
            //};
            //var sLocation3 = new StoreLocatoin()
            //{
            //    StoreName = "Store3"
            //};
            //var sLocation4 = new StoreLocatoin()
            //{
            //    StoreName = "Store4"
            //};
            //var sLocation5 = new StoreLocatoin()
            //{
            //    StoreName = "Store5"
            //};
            //context.StoreLocations.AddRange(new[] { sLocation1, sLocation2, sLocation3, sLocation4, sLocation5 });

            //var sale1 = new Sale()
            //{
            //    Date=DateTime.Now,
            //    Product=product1,
            //    Customer=customer1,
            //    StoreLocation=sLocation1
            //};
            //var sale2 = new Sale()
            //{
            //    Date = DateTime.Now,
            //    Product = product2,
            //    Customer = customer2,
            //    StoreLocation = sLocation2
            //};
           
            //var sale3 = new Sale()
            //{
            //    Date = DateTime.Now,
            //    Product = product3,
            //    Customer = customer3,
            //    StoreLocation = sLocation3
            //};
            //var sale4 = new Sale()
            //{
            //    Date = DateTime.Now,
            //    Product = product4,
            //    Customer = customer4,
            //    StoreLocation = sLocation4
            //};
            //var sale5 = new Sale()
            //{
            //    Date = DateTime.Now,
            //    Product = product5,
            //    Customer = customer5,
            //    StoreLocation = sLocation5
            //};
            //context.Sales.AddRange(new[] { sale1, sale2, sale3, sale4, sale5 });
            //context.SaveChanges();
            base.Seed(context);
        }
    }
}
