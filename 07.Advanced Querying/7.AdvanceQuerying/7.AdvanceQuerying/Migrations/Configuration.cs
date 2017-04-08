namespace AdvanceQuerying.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AdvanceQuerying.Data.QueryContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "AdvanceQuerying.Data.QueryContext";
        }

        protected override void Seed(AdvanceQuerying.Data.QueryContext context)
        {
            //var client = new Client
            //{
            //    Name = "Petar Ivanov",
            //    Adrress = "Tintyavva 17",
            //    Age = 18

            //};
            //var produrct = new Product
            //{
            //    Name = "Oil Pump"
            //};
            //var client2 = new Client
            //{
            //    Name = "Ivan Petrov",
            //    Adrress = "Pozitano 5",
            //    Age = 25
            //};
            //var client3 = new Client
            //{
            //    Name = " Vasil Vasilev",
            //    Age = 30,
            //};           
            //context.SaveChanges();
            //var order = new Order
            //{
            //    Client=client3
            //};
            ////client3.Orders.Add(order);
            
           
            //var client4 = new Client
            //{
            //    Name = "Anton Angelov",
            //    Age = 21
            //};


            //context.Clients.AddOrUpdate(c => c.Name, client, client2, client3, client4);
            //context.Products.AddOrUpdate(p => p.Name, produrct);
            //context.SaveChanges();
            //order.ClientId = client3.Id;
            //context.Orders.AddOrUpdate(o => o.ClientId, order);
            //context.SaveChanges();
        }
    }
}
