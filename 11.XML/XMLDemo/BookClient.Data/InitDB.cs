using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookClient.Data
{
    public static class InitDB
    {
        public static void Init()
        {
            var context = new BookContext();
            context.Database.Initialize(true);
        }

    }
}
