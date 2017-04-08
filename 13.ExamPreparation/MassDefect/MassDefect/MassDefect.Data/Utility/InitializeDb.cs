using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassDefect.Data.Utility
{
    public static class InitializeDb
    {
        public static void InitDB()
        {
            using (MassDefectContext context=new MassDefectContext())
            {
                context.Database.Initialize(true);
            }
        }
    }
}
