using System.Reflection;

namespace App.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;


    public class AppContext : DbContext
    {

        public AppContext()
            : base("name=AppContext")
        {
        }

    }
   

}