using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballManagerDEMO.Models;

namespace FootballManagerDEMO
{
    class StartUp
    {
        static void Main(string[] args)
        {
            //Initialize DB
            var context = new FMContext();
            //context.Database.Initialize(true); 
            context.Teams.Add(new Team() { Name = "Real Mdrid" });
            Team team = new Team { Name = "Beroe" };
            context.Teams.Add(team);
            context.SaveChanges();

            //Transaction
           //var trans= context.Database.Connection.BeginTransaction();
           // trans.Commit();
           // trans.Rollback();
            
            
        }
    }
}
