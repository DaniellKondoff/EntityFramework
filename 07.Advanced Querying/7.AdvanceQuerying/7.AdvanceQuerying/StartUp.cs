using AdvanceQuerying.Data;
using AdvanceQuerying.Models;
using EntityFramework.Extensions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace AdvanceQuerying
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var context = new QueryContext();
            context.Database.Initialize(true);

            //Native SQL
            //var query = "Select* from Clients Where Name LIKE @nameParam";
            //var nameParam = new SqlParameter("@nameParam", "Petar%");
            //var clients = context.Database.SqlQuery<Client>(query,nameParam);

            //foreach (var client in clients)
            //{
            //    Console.WriteLine(client.Name);
            //}

            //Object State Tracker
            //var client= context.Clients.FirstOrDefault();
            //Console.WriteLine(context.Entry(client).State);
            //client.Name = "Gosho";
            //context.Entry(client).State = System.Data.Entity.EntityState.Modified;
            //context.SaveChanges();

            //var clients= context.Clients.Take(3);

            //context.Clients.Update(c => new Client { Age = 18 });
            //context.SaveChanges();

            //context.Clients.Where(c => c.Age == 22).Delete();
            //context.SaveChanges();

            //Stored Proceedure

            //var param = new SqlParameter("@param", System.Data.SqlDbType.Int);
            //param.Value = 3;
            //context.Database.ExecuteSqlCommand("UpdateAge @param",param);

            //TypeOfLoading
            //Eager Loading
            //var oreder = context.Orders.Include(o=>o.Client).FirstOrDefault();
            //Console.WriteLine(oreder.Client.Name);
            //Explict Loading
            //var client = context.Clients.FirstOrDefault();
            //context.Entry(client).Collection(o => o.Orders).Load();
            //var ordersCollection = context.Clients.Local;
            //Console.WriteLine(ordersCollection.First().Orders.First().Id);

            //Cuncurrency Check

            var client = context.Clients.FirstOrDefault();
            client.Age = 33;

            var context2 = new QueryContext();
            var client2 = context2.Clients.FirstOrDefault();
            client2.Age = 55;

            context.SaveChanges();
            context2.SaveChanges();
            
           

        }
    }
}
