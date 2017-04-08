using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Photographers.Data;
using Photographers.Models;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Validation;
using Photographers.Attribute;

namespace Photographers
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var context = new PhotoContext();

            ////Tag
            //Tag tag = new Tag()
            //{
            //    Label = "hahah"
            //};
            //context.Tags.Add(tag);
            //try
            //{
            //    context.SaveChanges();
            //}
            //catch (DbEntityValidationException e)
            //{
            //    tag.Label = TagTransformer.Transfrom(tag.Label);
            //    context.SaveChanges();
            //}

            Console.WriteLine(context.Photographers.Count());



        }
    }
}
