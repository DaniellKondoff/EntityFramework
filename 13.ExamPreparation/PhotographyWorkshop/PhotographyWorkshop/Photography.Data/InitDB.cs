using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photography.Data
{
    public static class InitDB
    {
       public static void InitializeDB()
        {
            PhotoWorkContext context = new PhotoWorkContext();
            context.Database.Initialize(true);
        }      
    }
}
