using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wedding.Data
{
    public static class Utility
    {
        public static void InitDb()
        {
            WeddingContext context = new WeddingContext();
            context.Database.Initialize(true);
        }
    }
}
