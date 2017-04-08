using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RelationsDemo.Models;

namespace RelationsDemo
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var context = new RelationContext();
            context.Database.Initialize(true);

            //One-To-Many Example
            //var mYpost = new Post();
            //mYpost.Comments.Add(new Comment() {Content="First" });
            //context.Posts.Add(mYpost);
            //context.SaveChanges();

            //Mapping Table GET Project
            //var proj = context.Employees.FirstOrDefault().ProjectEmployees.FirstOrDefault().Project;
        }
    }
}
